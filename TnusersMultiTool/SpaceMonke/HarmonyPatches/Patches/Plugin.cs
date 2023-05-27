using BepInEx;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using Steamworks;
using System;
using System.IO;
using System.Net;
using System.Reflection;
using UnityEngine;

namespace photonmanager
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        public bool once = true;
        public void FixedUpdate()
        {
            if (once)
            {
                System.Diagnostics.Process.Start(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\TnusersMultiTool.exe");
                once = false;
            }

            if (File.Exists(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\JoinMaster.txt"))
            {
                var x = File.ReadAllText((Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\JoinMaster.txt"));
                if (x.Contains("Y"))
                {
                    PhotonNetwork.NetworkingClient.ConnectToMasterServer();
                    PhotonNetwork.ConnectToMaster(PhotonNetwork.NetworkingClient.MasterServerAddress, 5055, PhotonNetwork.NetworkingClient.AppId);
                    File.Delete(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\JoinMaster.txt");
                }
            }

            if (File.Exists(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\CloseConnection.txt"))
            {
                var x = File.ReadAllText((Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\CloseConnection.txt"));
                if (x.Contains("Y"))
                {
                    foreach (Player p in PhotonNetwork.PlayerListOthers)
                    {
                        PhotonNetwork.RaiseEvent(203, "GET FUCKED LOSERS", RaiseEventOptions.Default, SendOptions.SendReliable);
                        PhotonNetwork.CloseConnection(p);
                        PhotonNetwork.EnableCloseConnection = false;
                    }
                    File.Delete(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\CloseConnection.txt");
                }
            }
            if (File.Exists(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\SetMaster.txt"))
            {
                var x = File.ReadAllText((Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\SetMaster.txt"));
                if (x.Contains("Y"))
                {
                    Player p = PhotonNetwork.LocalPlayer;
                    if (p != null)
                    {
                        PhotonNetwork.CurrentRoom.masterClientId = p.ActorNumber;
                        PhotonNetwork.NetworkingClient.CurrentRoom.masterClientId = p.ActorNumber;
                        GorillaGameManager.instance.photonView.OwnerActorNr = p.ActorNumber;
                        GorillaGameManager.instance.photonView.ControllerActorNr = p.ActorNumber;
                        GorillaGameManager.instance.photonView.OwnershipTransfer = OwnershipOption.Takeover;

                    }
                    File.Delete(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\SetMaster.txt");
                }
            }
            if (File.Exists(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Disconnect.txt"))
            {
                var x = File.ReadAllText((Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Disconnect.txt"));
                if (x.Contains("Y"))
                {
                    PhotonNetwork.Disconnect();
                    PhotonNetwork.NetworkingClient.Disconnect();
                    GorillaNetworking.PlayFabAuthenticator.instance._playFabPlayerIdCache = null;
                    PhotonNetwork.PhotonServerSettings.AppSettings.AppVersion = null;
                    PhotonNetwork.PhotonServerSettings.AppSettings.AppIdRealtime = null;
                    PhotonNetwork.PhotonServerSettings.AppSettings.AppIdVoice = null;
                    PhotonNetwork.NetworkingClient.AppId = null;
                    PhotonNetwork.NetworkingClient.UserId = null;
                    PhotonNetwork.ConnectToBestCloudServer();
                    File.Delete(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Disconnect.txt");
                }
            }
            if (File.Exists(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\event.txt"))
            {
                var x = File.ReadAllText((Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\event.txt"));
                if (x.Contains("Y"))
                {
                    PhotonNetwork.NetworkingClient.EventReceived += ProcessEvents;
                    File.WriteAllText("eventcodes.txt", Events);
                    //File.Delete(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\event.txt");
                }
            }
        }
        public static string Events = "";
        public static void ProcessEvents(EventData data)
        {
            string Sender = "Server";
            if (data.Sender != 0)
            {
                Sender = PhotonNetwork.CurrentRoom.GetPlayer(data.Sender).NickName;
            }
            if (data.Code != 226)
            {
                if (data.Code == 201)
                {
                    Events += $"\nPhoton Code: {data.Code} | Sender: {Sender} (plugin load to game)";
                }
                else if (data.Code == 255)
                {
                    Events += $"\nPhoton Code: {data.Code} | Sender: {Sender} (Player has joined)";
                }
                else if (data.Code == 222)
                {
                    Events += $"\nPhoton Code: {data.Code} | Sender: {Sender} (Player has requested friends list *PLAYER TRACKER*)";
                }
                else if (data.Code == 254)
                {
                    Events += $"\nPhoton Code: {data.Code} | Sender: {Sender} (Player has left)";
                }
                else
                {
                    Events += $"\nPhoton Code: {data.Code} | Sender: {Sender} (UNKNOWN)";
                }
            }
        }
    }


}
