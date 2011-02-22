// 
// ViMotion.cs
//  
// Author:
//       sehe <${AuthorEmail}>
// 
// Copyright (c) 2011 sehe
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
using Mono.TextEditor.Vi;
using Mono.TextEditor;

namespace Mono.TextEditor.Vi
{
	[Flags]
	public enum ViMotionStyle
	{
		Unspecified		= 0x00,
		//
		Linewise 		= 0x01,
		Characterwise	= 0x02,
		Blockwise		= 0x04,
		//
		Inclusive		= 0x08,
		Exclusive		= 0x10,
		//
		Wises = Linewise | Characterwise | Blockwise,
		Sives = Inclusive | Exclusive
	}
	
	/// <summary>
	/// Vi motion.
	/// 
	/// Initialize from command default (bias) and allow user to override or context dependent tweaks
	/// matching Vim behaviour
	/// </summary>
	public struct ViMotion
	{
		public ViMotionStyle Style { get; set; }
		public DocumentLocation Start { get; set; }
		public DocumentLocation End   { get; set; }
		
		// motion.txt: Linewise motions always include the start and end position.
		public void ForceLinewise() 	 { Style = (Style & ~ViMotionStyle.Wises) | ViMotionStyle.Linewise; }
		public void ForceCharacterwise() { Style = (Style & ~ViMotionStyle.Wises) | ViMotionStyle.Characterwise; } 
		public void ForceBlockwise()     { Style = (Style & ~ViMotionStyle.Wises) | ViMotionStyle.Blockwise; } 
		//
		public void MakeExclusive()		 { Style = (Style & ~ViMotionStyle.Sives) | ViMotionStyle.Exclusive; }
		public void MakeInclusive()		 { Style = (Style & ~ViMotionStyle.Sives) | ViMotionStyle.Inclusive; }
		
		public void AutoLinewise(TextEditorData data)
		{
			if (ViMotionStyle.Unspecified != (Style & ViMotionStyle.Wises))
				return; // already given or overruled
			
			// Generally, motions that move between lines affect lines (are linewise), and motions that 
			// move within a line affect characters (are characterwise). However, there are some exceptions. 
			bool linewise = Start.Line != End.Line;
			
			/* exclusive-linewise: 
			 *
			 * If the motion is exclusive, the end of the motion is in column 1
			 * and the start of the motion was at or before the first non-blank
			 * in the line, the motion becomes linewise. 
			 * Example: If a paragraph begins with some blanks and you do "d}"
			 * while standing on the first non-blank, all the lines of the
			 * paragraph are deleted, including the blanks. If you do a put
			 * now, the deleted lines will be inserted below the cursor
			 * position.
			 */
			if (!linewise)
			{
				if (ViMotionStyle.Unspecified != (Style & ViMotionStyle.Exclusive))
				{
					if (0 == End.Column && Start.Column <= data.GetLineIndent(Start.Line).Length)
					{
						Console.WriteLine("Activating exclusive-linewise for {0} - {1}", Start, End);
						linewise = true;
					}
				}
			}
			
			if (linewise)
				ForceLinewise();
		}
		
	}
}

