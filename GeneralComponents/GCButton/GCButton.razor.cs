using Microsoft.AspNetCore.Components;
using System;

namespace GeneralComponents.GCButton
{
    public class GCButtonBase : ComponentBase
    {
        //
        //  2019-03-05  Mark Stega
        //              Created
        //

        public const string kStdId_Cancel = "CANCEL";
        public const string kStdId_No = "NO";
        public const string kStdId_OK = "OK";
        public const string kStdId_Yes = "YES";

        public void InternalClick()
        {
            OnClickAction.InvokeAsync(new GCButtonRes(ButtonId, UserData));
        }

        [Parameter] public string ButtonId { get; set; }
        [Parameter] public object UserData { get; set; } = null;
        [Parameter] public string ButtonText { get; set; }
        [Parameter] public EventCallback<GCButtonRes> OnClickAction { get; set; }
    }

    public class GCButtonRes : EventArgs
    {
        public GCButtonRes(string id, object data)
        {
            ButtonId = id;
            UserData = data;
        }

        public string ButtonId { get; set; }
        public object UserData { get; set; } = null;
    };
}
