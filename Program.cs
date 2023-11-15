using System.Net.Sockets;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

using var tcpClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
try{
    await tcpClient.ConnectAsync("192.168.1.184", 1776);
    while(true)
    {
        System.Console.WriteLine("Введите ");
        string command = Console.ReadLine() + '\n';

        byte[] reqestData = Encoding.UTF8.GetBytes(command);

        await tcpClient.SendAsync(reqestData);

        Console.WriteLine();

        byte[] data = new byte[512];

        int bytes = await tcpClient.ReceiveAsync(data);

        string time = Encoding.UTF8.GetString(data, 0, bytes);

        Console.WriteLine("");
        
    }
}
catch (Exception ex){
    Console.WriteLine(ex.Message);
}