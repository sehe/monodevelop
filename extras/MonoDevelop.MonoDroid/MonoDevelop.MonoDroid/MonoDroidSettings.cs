// 
// MonoDroidCommands.cs
//  
// Author:
//       Michael Hutchinson <mhutchinson@novell.com>
// 
// Copyright (c) 2010 Novell, Inc. (http://www.novell.com)
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

using MonoDevelop.Core;
using System;
using System.Xml.Linq;
using System.IO;
using MonoDroid;

namespace MonoDevelop.MonoDroid
{
	public static class MonoDroidSettings
	{
		public static int DebuggerPort {
			get { return PropertyService.Get ("MonoDroid.Debugger.Port", 10000); }
		}
		
		public static int DebuggerOutputPort {
			get { return PropertyService.Get ("MonoDroid.Debugger.OutputPort", 10001); }
		}
		
		public static System.Net.IPAddress GetDebuggerHostIP (bool emulator)
		{
			if (emulator)
				return System.Net.IPAddress.Loopback;

			var ipStr = PropertyService.Get ("MonoDroid.Debugger.HostIP", "");
			try {
				if (!string.IsNullOrEmpty (ipStr))
					return System.Net.IPAddress.Parse (ipStr);
			} catch (Exception e) {
				LoggingService.LogInfo ("Error parsing Debugger HostIP: {0}: {1}", ipStr, e);
			}
			
			var entry = System.Net.Dns.GetHostEntry (System.Net.Dns.GetHostName ());
			foreach (var addr in entry.AddressList)
				if (addr.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
					return addr;
			
			throw new Exception ("Could not get host address");
		}
	}
}
