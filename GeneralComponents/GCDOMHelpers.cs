using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace GeneralComponents
{
    public static class GCDOMHelpers
    {
        public static ValueTask<string> setDOMElementVal(this ElementReference elementRef, IJSRuntime jsRuntime, string toSet)
        {
            return jsRuntime.InvokeAsync<string>("customizationJsFunctions.setDOMElementVal", elementRef, toSet);
        }

        public static ValueTask<string> getDOMElementVal(this ElementReference elementRef, IJSRuntime jsRuntime)
        {
            return jsRuntime.InvokeAsync<string>("customizationJsFunctions.getDOMElementVal", elementRef);
        }

        public static ValueTask<string> setDOMElementBgnClr(this ElementReference elementRef, IJSRuntime jsRuntime, string toSet)
        {
            return jsRuntime.InvokeAsync<string>("customizationJsFunctions.setDOMElementBgnClr", elementRef, toSet);
        }

        public static ValueTask<string> setModalState(IJSRuntime jsRuntime, bool toSet)
        {
            return jsRuntime.InvokeAsync<string>("customizationJsFunctions.setModalState", toSet);
        }
    }
}
