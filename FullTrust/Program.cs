using System;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth;
using Windows.Devices.Radios;

//[assembly: ArmDot.Client.HideStrings()]
//[assembly: ArmDot.Client.ObfuscateNamesAttribute()]
//[assembly: ArmDot.Client.ObfuscateNamespaces()]
//[assembly: ArmDot.Client.ObfuscateControlFlow()]

//[assembly: ArmDot.Client.VirtualizeCode()]
namespace FullTrust
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Hello World";
            var bluetoothAdapter = await BluetoothAdapter.GetDefaultAsync();
            try
            {
                var radio = await GetRadioFromBluetoothAdapterAsync(bluetoothAdapter);
                Console.WriteLine(radio.Name);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"{ex.HelpLink} {ex.Message}");
            }
            Console.WriteLine("This process runs at the full privileges of the user and has access to the entire public desktop API surface");
            Console.WriteLine("\r\nPress any key to exit ...");
            Console.ReadLine();
        }

        [ArmDot.Client.VirtualizeCode(Enable = true, Inherit = true)]
        private async static Task<Radio> GetRadioFromBluetoothAdapterAsync(BluetoothAdapter adapter, int timeout = 5_000)
        {
            DateTime start = DateTime.UtcNow.AddMilliseconds(timeout);
            Radio radio = null;

            while (radio == null && start > DateTime.UtcNow)
            {
                try
                {
                    //Logger.Debug($"Time: {start} > {DateTime.UtcNow}", category: tag);
                    radio = await adapter.GetRadioAsync();
                    break;
                }
                catch (Exception e)
                {
                    await Task.Run(() => Thread.Sleep(1000));
                    if ((uint)e.HResult == 0x80070490)
                        Console.WriteLine($"{e.HResult} {e.Message}");
                }
            }

            return radio;
        }
    }
}
