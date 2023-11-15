using CustomAppAPI;
using Reptile;
using System.IO;
using UnityEngine;

namespace FastTravel
{
    public class AppFastTravel : CustomApp
    {
        public override string DisplayName => "call taxi";
        public override Texture2D Icon => LoadTexture(Path.Combine(FastTravelMod.Instance.ModFolderPath, "taxiIcon.png"));

        public override void OnAppEnable()
        {
            base.OnAppEnable();

            MyPhone.CloseCurrentApp();
            MyPhone.TurnOff();

            if (!Core.Instance.SaveManager.CurrentSaveSlot.GetCurrentStageProgress().taxiFound)
            {
                return;
            }

            Taxi taxi = FindObjectOfType<Taxi>(true); // the only time findobjectoftype is somewhat acceptable
            if (taxi == null)
            {
                FastTravelMod.Log.LogWarning("No Taxi found.");
                return;
            }
            NPC taxiNpc = taxi.GetComponent<NPC>();
            if (taxiNpc == null)
            {
                FastTravelMod.Log.LogWarning("No Taxi NPC found.");
                return;
            }

            taxiNpc.StartTalkingWithConvoStarter(NPC.ConversationStarter.TAXI_DANCE);
        }
    }
}
