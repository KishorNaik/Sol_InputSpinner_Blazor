using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputSpinner
{
    public partial class InputSpinnerComponent
    {
        #region Private Variables

        private Task<IJSObjectReference> _module = null;

        #endregion Private Variables

        #region Inject

        [Inject]
        public IJSRuntime JavascriptRuntime { get; set; }

        #endregion Inject

        #region Load Input Spinner

        #region Parameters

        [Parameter]
        public int Max { get; set; }

        [Parameter]
        public int Min { get; set; }

        [Parameter]
        public int Decimals { get; set; }

        [Parameter]
        public double Step { get; set; }

        [Parameter]
        public String Suffix { get; set; }

        [Parameter]
        public String Prefix { get; set; }

        #endregion Parameters

        #region Private Property

        private ElementReference InputElementReference { get; set; }

        #endregion Private Property

        #region Private Method

        private void LoadJsModules()
        {
            _module = JavascriptRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/InputSpinner/inputSpinner.js").AsTask();
        }

        private async Task LoadInputSpinnerJs()
        {
            await (await _module).InvokeVoidAsync(identifier: "setInputSpinner", InputElementReference);
        }

        #endregion Private Method

        #endregion Load Input Spinner

        #region OnChange Event

        #region Parameters

        private double _SpinnerValue;

        [Parameter]
        public double SpinnerValue
        {
            get => this._SpinnerValue;
            set
            {
                if (_SpinnerValue == value) return;
                _SpinnerValue = value;
                if (SpinnerValueChanged.HasDelegate)
                {
                    Action action = async () =>
                     {
                         await (await _module).InvokeVoidAsync(identifier: "setInputSpinnerData", InputElementReference, this.SpinnerValue);
                     };
                    action();
                }
            }
        }

        [Parameter]
        public EventCallback<double> SpinnerValueChanged { get; set; }

        [Parameter]
        public Action<double> OnChangeEventHandler { get; set; }

        #endregion Parameters

        #region Event

        private async Task OnChangeInput(ChangeEventArgs eventArgs)
        {
            this.SpinnerValue = Convert.ToDouble(eventArgs.Value);
            await SpinnerValueChanged.InvokeAsync(this.SpinnerValue);

            OnChangeEventHandler?.Invoke(this.SpinnerValue);
            base.StateHasChanged();
        }

        #endregion Event

        #endregion OnChange Event

        #region Protected Method

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                // Step 1 Load Input Spinner
                LoadJsModules();
                await this.LoadInputSpinnerJs();

                base.StateHasChanged();
            }
        }

        #endregion Protected Method
    }
}