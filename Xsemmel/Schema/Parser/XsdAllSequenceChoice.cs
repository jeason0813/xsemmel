using System;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml;

namespace XSemmel.Schema.Parser {

    public class XsdAllSequenceChoice : XsdNode, IXsdCountable
    {

        public XsdAllSequenceChoice(XmlNode node, string name) : base(node)
        {
            Name = name;
            switch (Name)
            {
                case "choice":
                case "sequence":
                case "all":
                    MinOccurs = "1";
                    MaxOccurs = "1";
                    break;
                default:
                    Debug.Fail("Unsupported type: "+Name);
                    break;
            }
            {
                string attr = VisualizerHelper.GetAttr(node, "minOccurs");
                if (attr != null)
                {
                    MinOccurs = attr;
                }
            }
            {
                string attr = VisualizerHelper.GetAttr(node, "maxOccurs");
                if (attr != null)
                {
                    MaxOccurs = attr;
                }
            }
        }

        public string MinOccurs { get; set; }
        public string MaxOccurs { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Name);
            VisualizerHelper.ToStringCountable(this, sb);
            return sb.ToString();
        }


        public override UIElement GetPaintComponent(XsdVisualizer.PaintOptions po, int fontSize)
        {
            if (fontSize <= 0) return null;

            StackPanel pnl = new StackPanel();

            Rectangle rect = new Rectangle();
            rect.Height = 2;
            rect.Fill = Brushes.LightGray;
            rect.HorizontalAlignment = HorizontalAlignment.Stretch;
            rect.Margin = new Thickness(2);
            
            pnl.Children.Add(rect);

            pnl.Children.Add(GetPaintTitle(po, fontSize));

            pnl.Children.Add(GetPaintChildren(po, fontSize - 1));

            addMouseEvents(po, pnl, this);

            return pnl;
        }

        protected override UIElement GetPaintTitle(XsdVisualizer.PaintOptions po, int fontSize)
        {
            return new TextBlock
            {
                Text = ToString(),
                Foreground = Brushes.Gray,
                FontSize = fontSize,
                FontStyle = FontStyles.Italic,
            };
        }

    }
}