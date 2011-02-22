// 
// ViMark.cs
//  
// Author:
//       Sanjoy Das <sanjoy@playingwithpointers.com>
// 
// Copyright (c) 2010 Sanjoy Das
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Linq;
using Cairo;

namespace Mono.TextEditor.Vi
{
	public class ViMark : Mono.TextEditor.TextMarker, IIconBarMarker
	{
		public char MarkCharacter {get; private set;}
		
		/// <summary>
		/// Only way to construct a ViMark.
		/// </summary>
		/// <param name="markCharacter">
		/// The <see cref="System.Char"/> with which the ViMark object needs to be
		/// associated.
		/// </param>
		public ViMark (char markCharacter) {
			MarkCharacter = markCharacter;
			IsVisible = true;
			Flags = TextMarkerFlags.DrawsSelection;
		}
		
		public int ColumnNumber {get; protected set;}
		
		public void SaveMark (TextEditorData data) {
		
			if (base.LineSegment != null) {
				// Remove the marker first
				data.Document.RemoveMarker (this);
			}
		
			// Is there a better way of doing this?
			int lineNumber = data.IsSomethingSelected ? data.MainSelection.MinLine : data.Caret.Line;
			base.LineSegment = data.Document.GetLine (lineNumber);
			ColumnNumber = data.Caret.Column;
			data.Document.AddMarker(lineNumber, this);
			
			data.Document.RequestUpdate (new UpdateAll ());
			data.Document.CommitDocumentUpdate ();
			
		}
		
		public void LoadMark (TextEditorData data) {
			int x = data.Document.OffsetToLineNumber (base.LineSegment.Offset);
			data.Caret.Line = x;
			int len = base.LineSegment.Length;
			if (ColumnNumber >= len) {
				// Check if the line has been truncated after the setting the mark
				data.Caret.Column = len - 1;
			} else {
				data.Caret.Column = ColumnNumber;
			}
		}
		
		public override ChunkStyle GetStyle (ChunkStyle baseStyle)
		{
			return baseStyle;
		}
		
		protected IEnumerable<ViMark> PeerMarks(LineSegment lineSegment)
		{
			return lineSegment.Markers.OfType<ViMark>();	
		}
		
		public void DrawIcon (TextEditor editor, Cairo.Context cr, LineSegment lineSegment, int lineNumber, double x, double y, double width, double height)
		{
			if (null == lineSegment)
				return;

			var marks = PeerMarks(lineSegment);

			if (this == marks.FirstOrDefault()) {
				Cairo.Color color1 = editor.ColorStyle.BookmarkColor1;  // TODO configuration setting for ViMark
				Cairo.Color color2 = editor.ColorStyle.BookmarkColor2;

				var label = marks.Skip(1).Any()? "..." : "'" + MarkCharacter;

				DrawRoundRectangle (cr, x + 1, y + 1, 8, width - 4, height - 4);
				Cairo.Gradient pat = new Cairo.LinearGradient (x + width / 4, y, x + width / 2, y + height - 4);
				pat.AddColorStop (0, color1);
				pat.AddColorStop (1, color2);
				cr.Pattern = pat;
				cr.FillPreserve ();

				pat = new Cairo.LinearGradient (x, y + height, x + width, y);
				pat.AddColorStop (0, color2);
				//pat.AddColorStop (1, color1);
				cr.Pattern = pat;
				cr.Stroke ();

				cr.Color = new Color(0,0,0,.7);
				//cr.SelectFontFace("Georgia", FontSlant.Normal, FontWeight.Bold);
				//cr.SetFontSize(12.2);
				var fe = cr.FontExtents;
				var te = cr.TextExtents(label);
				cr.MoveTo(x + width/2  - te.XBearing - te.Width/2,
	          			  y + height/2 - fe.Descent + fe.Height/2);
				cr.ShowText(label);

			}
		}

		public static void DrawRoundRectangle (Cairo.Context cr, double x, double y, double r, double w, double h)
		{
			const double ARC_TO_BEZIER = 0.55228475;
			double radius_x = r;
			double radius_y = r / 4;

			if (radius_x > w - radius_x)
				radius_x = w / 2;

			if (radius_y > h - radius_y)
				radius_y = h / 2;

			double c1 = ARC_TO_BEZIER * radius_x;
			double c2 = ARC_TO_BEZIER * radius_y;

			cr.NewPath ();
			cr.MoveTo (x + radius_x, y);
			cr.RelLineTo (w - 2 * radius_x, 0.0);
			cr.RelCurveTo (c1, 0.0,
			               radius_x, c2,
			               radius_x, radius_y);
			cr.RelLineTo (0, h - 2 * radius_y);
			cr.RelCurveTo (0.0, c2, c1 - radius_x, radius_y, -radius_x, radius_y);
			cr.RelLineTo (-w + 2 * radius_x, 0);
			cr.RelCurveTo (-c1, 0, -radius_x, -c2, -radius_x, -radius_y);
			cr.RelLineTo (0, -h + 2 * radius_y);
			cr.RelCurveTo (0.0, -c2, radius_x - c1, -radius_y, radius_x, -radius_y);
			cr.ClosePath ();
		}

		public void MousePress (MarginMouseEventArgs args)
		{
		}

		public void MouseRelease (MarginMouseEventArgs args)
		{
		}

		public void MouseHover (MarginMouseEventArgs args)
		{
			var names = PeerMarks(args.LineSegment?? base.LineSegment).Select(m => "'" + m.MarkCharacter);
			var last = names.LastOrDefault();
			if (null != last)
				args.Editor.TooltipText = "Vi Marks: " + string.Join(", ", names.Take(names.Count()-1).ToArray()) + " and " + last;
		}
	}
	
}
