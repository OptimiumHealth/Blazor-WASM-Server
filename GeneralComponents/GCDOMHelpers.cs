using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace GeneralComponents
{
    public static class GCDOMHelpers
    {
        public static Task setDOMElementVal(this ElementReference elementRef, IJSRuntime jsRuntime, string toSet)
        {
            return jsRuntime.InvokeAsync<string>("customizationJsFunctions.setDOMElementVal", elementRef, toSet);
        }

        public static Task<string> getDOMElementVal(this ElementReference elementRef, IJSRuntime jsRuntime)
        {
            return jsRuntime.InvokeAsync<string>("customizationJsFunctions.getDOMElementVal", elementRef);
        }

        public static Task<string> setDOMElementBgnClr(this ElementReference elementRef, IJSRuntime jsRuntime, string toSet)
        {
            return jsRuntime.InvokeAsync<string>("customizationJsFunctions.setDOMElementBgnClr", elementRef, toSet);
        }

        public static Task<string> setModalState(IJSRuntime jsRuntime, bool toSet)
        {
            return jsRuntime.InvokeAsync<string>("customizationJsFunctions.setModalState", toSet);
        }
    }
}
