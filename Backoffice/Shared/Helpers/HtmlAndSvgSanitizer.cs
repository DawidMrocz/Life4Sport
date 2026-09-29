using Ganss.Xss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Shared.Helpers
{
    public static class HtmlAndSvgSanitizer
    {
        private static readonly IList<string> allowedHtmlTags;

        private static readonly IList<string> allowedHtmlAttributes;

        private static readonly IList<string> allowedSvgTags;

        private static readonly IList<string> allowedSvgAttributes;

        private static readonly HtmlSanitizer sanitizer;

        static HtmlAndSvgSanitizer()
        {
            allowedHtmlTags = new List<string> { "meta", "html", "head", "body" };
            allowedHtmlAttributes = new List<string> { "http-equiv", "content", "name", "itemscope", "itemprop", "itemtype", "class", "style" };
            allowedSvgTags = new List<string>
            {
                "a", "animate", "animateColor", "animateMotion", "animateTransform", "circle", "defs", "desc", "ellipse", "font-face",
                "font-face-name", "font-face-src", "foreignObject", "g", "glyph", "hkern", "line", "linearGradient", "marker", "metadata",
                "missing-glyph", "mpath", "path", "polygon", "polyline", "radialGradient", "rect", "set", "stop", "svg",
                "switch", "text", "title", "tspan", "use"
            };
            allowedSvgAttributes = new List<string>
            {
                "accent-height", "accumulate", "additive", "alphabetic", "arabic-form", "ascent", "attributeName", "attributeType", "baseProfile", "bbox",
                "begin", "by", "calcMode", "cap-height", "class", "color", "color-rendering", "content", "cx", "cy",
                "d", "descent", "display", "dur", "dx", "dy", "end", "fill", "fill-opacity", "fill-rule",
                "font-family", "font-size", "font-stretch", "font-style", "font-variant", "font-weight", "from", "fx", "fy", "g1",
                "g2", "glyph-name", "gradientUnits", "hanging", "height", "horiz-adv-x", "horiz-origin-x", "id", "ideographic", "k",
                "keyPoints", "keySplines", "keyTimes", "lang", "marker-end", "marker-mid", "marker-start", "markerHeight", "markerUnits", "markerWidth",
                "mathematical", "max", "min", "name", "offset", "opacity", "orient", "origin", "overline-position", "overline-thickness",
                "panose-1", "path", "pathLength", "points", "preserveAspectRatio", "r", "refX", "refY", "repeatCount", "repeatDur",
                "requiredExtensions", "requiredFeatures", "restart", "rotate", "rx", "ry", "slope", "stemh", "stemv", "stop-color",
                "stop-opacity", "strikethrough-position", "strikethrough-thickness", "stroke", "stroke-dasharray", "stroke-dashoffset", "stroke-linecap", "stroke-linejoin", "stroke-miterlimit", "stroke-opacity",
                "stroke-width", "systemLanguage", "target", "text-anchor", "to", "transform", "type", "u1", "u2", "underline-position",
                "underline-thickness", "unicode", "unicode-range", "units-per-em", "values", "version", "viewBox", "visibility", "width", "widths",
                "x", "x-height", "x1", "x2", "xlink:actuate", "xlink:arcrole", "xlink:href", "xlink:role", "xlink:show", "xlink:title",
                "xlink:type", "xml:base", "xml:lang", "xml:space", "xmlns", "xmlns:xlink", "y", "y1", "y2", "zoomAndPan"
            };
            sanitizer = new HtmlSanitizer();
            foreach (string allowedHtmlTag in allowedHtmlTags)
            {
                sanitizer.AllowedTags.Add(allowedHtmlTag);
            }

            foreach (string allowedHtmlAttribute in allowedHtmlAttributes)
            {
                sanitizer.AllowedAttributes.Add(allowedHtmlAttribute);
            }

            foreach (string allowedSvgTag in allowedSvgTags)
            {
                sanitizer.AllowedTags.Add(allowedSvgTag);
            }

            foreach (string allowedSvgAttribute in allowedSvgAttributes)
            {
                sanitizer.AllowedAttributes.Add(allowedSvgAttribute);
            }

            sanitizer.AllowDataAttributes = true;
            sanitizer.AllowedSchemes.Add("mailto");
        }

        public static string SanitizeText(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            string text2 = sanitizer.Sanitize(text);
            bool flag = text2.CompareTo(text.Trim()) != 0;
            return text2;
        }

        public static MemoryStream SanitizeFile(Stream file)
        {
            using StreamReader streamReader = new StreamReader(file);
            string text = streamReader.ReadToEnd();
            string s = SanitizeText(text);
            return new MemoryStream(Encoding.UTF8.GetBytes(s));
        }

        public static byte[] SanitizeFile(byte[] file)
        {
            string @string = Encoding.UTF8.GetString(file);
            string s = SanitizeText(@string);
            return Encoding.UTF8.GetBytes(s);
        }

        //public static string MoveCssInline(string source)
        //{
        //    return PreMailer.Net.PreMailer.MoveCssInline(source).Html;
        //}
    }
}
