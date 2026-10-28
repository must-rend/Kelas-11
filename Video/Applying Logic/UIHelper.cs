using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace ContohSoal1
{
    public static class UIHelper
    {
        // Normalize: hide PictureBoxes, transfer their Click handlers to matching labels/buttons,
        // and enforce white backgrounds for forms, panels, buttons and data grids.
        public static void Normalize(Control root)
        {
            System.Action<Control> normalize = null;
            normalize = c =>
            {
                // Transfer PictureBox click handlers to a matching label/button (if any), then remove from parent
                if (c is PictureBox pb)
                {
                    try
                    {
                        // get Click event key from Control
                        FieldInfo clickKey = typeof(Control).GetField("EventClick", BindingFlags.Static | BindingFlags.NonPublic);
                        object key = clickKey?.GetValue(null);

                        PropertyInfo eventsProp = typeof(Component).GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
                        EventHandlerList list = eventsProp?.GetValue(pb) as EventHandlerList;

                        Delegate d = null;
                        if (list != null && key != null)
                            d = list[key];

                        // find target control by name: try labelX or buttonX where X is suffix of pictureBox name
                        Control parent = pb.Parent;
                        Control target = null;
                        if (!string.IsNullOrEmpty(pb.Name) && parent != null)
                        {
                            // example: pictureBox7 -> label7
                            string suffix = pb.Name.Replace("pictureBox", "");
                            string labelName = "label" + suffix;
                            string buttonName = "button" + suffix;
                            target = parent.Controls[labelName] ?? parent.Controls[buttonName];
                            // fallback: find any label in same container with matching Location.Y
                            if (target == null)
                            {
                                foreach (Control s in parent.Controls)
                                {
                                    if (s is Label)
                                    {
                                        // choose label that is horizontally to the right of the picture
                                        if (s.Left > pb.Left)
                                        {
                                            target = s;
                                            break;
                                        }
                                    }
                                }
                            }
                        }

                        if (d != null && target != null)
                        {
                            foreach (Delegate handler in d.GetInvocationList())
                            {
                                if (handler is EventHandler eh)
                                {
                                    target.Click += eh;
                                }
                            }
                        }

                        // remove picturebox from parent controls so it's effectively gone at runtime
                        if (parent != null && parent.Controls.Contains(pb))
                            parent.Controls.Remove(pb);

                        pb.Image = null;
                    }
                    catch
                    {
                        // ignore any reflection issues and continue
                        pb.Visible = false;
                        pb.Image = null;
                    }
                    return; // no need to traverse children
                }

                if (c is Button btn)
                {
                    btn.BackColor = System.Drawing.Color.White;
                    btn.UseVisualStyleBackColor = false;
                }
                if (c is Panel p)
                {
                    p.BackColor = System.Drawing.Color.White;
                }
                if (c is DataGridView dgv)
                {
                    dgv.BackgroundColor = System.Drawing.Color.White;
                }
                foreach (Control child in c.Controls)
                    normalize(child);
            };
            normalize(root);
            if (root is Form f)
                f.BackColor = System.Drawing.Color.White;
        }
    }
}
