using System;
using System.Threading;
using Kolrabi.SteamController;

namespace Test
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");

			var controllers = SteamControllerDevice.OpenControllers ();

		    for(var i = 0; i < controllers.Length; i++)
		    {
		        var i1 = i;
		        new Thread(t => PollThread(i1, controllers[i1])).Start();
		    }
        }

	    public  static void PollThread(int id, SteamControllerDevice controller)
	    {
	        while (true)
	        {
	            var evt = controller.ReadEvent();
	            if (evt != null)
	            {
	                if (evt is ConnectionEvent && ((ConnectionEvent)evt).State == WirelessState.Connected)
	                {
	                    controller.Configuration = 0;
	                }

	                var debugStr = string.Empty;
	                controller.UpdateState(evt);
	                debugStr += "Controller " + id;
	                debugStr += "\n  Buttons:  " + controller.ButtonState;
	                debugStr += "\n  Triggers: " + controller.LeftTrigger + ", " + controller.RightTrigger;
	                debugStr += "\n  Stick:    " + controller.Stick.x + ", " + controller.Stick.y;
	                debugStr += "\n  LPad:     " + controller.LeftPad.x + ", " + controller.LeftPad.y;
	                debugStr += "\n  RPad:     " + controller.RightPad.x + ", " + controller.RightPad.y;
	                debugStr += "\n";
                    Console.WriteLine(debugStr);
	            }
                Thread.Sleep(10);
	        }

        }
    }
}
