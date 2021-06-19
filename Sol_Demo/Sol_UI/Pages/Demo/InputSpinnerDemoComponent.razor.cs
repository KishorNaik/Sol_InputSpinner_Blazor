using InputSpinner;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_UI.Pages.Demo
{
    public partial class InputSpinnerDemoComponent
    {
        #region Private Property

        private InputSpinnerComponent InputSpinnerCompValueRupess { get; set; }

        private InputSpinnerComponent InputSpinnerCompValueDegree { get; set; }

        private Double ValueRuppes { get; set; }
        private Double ValueDegree { get; set; }

        #endregion Private Property

        #region Event Handler

        private void InputSpinnerCompValueRupess_OnSubmit()
        {
            ValueRuppes = 10;
            base.StateHasChanged();
        }

        private void InputSpinnerCompValueRupess_OnChange(double value)
        {
            Debug.WriteLine(value);
            ValueRuppes = value;
            base.StateHasChanged();
        }

        private void InputSpinnerCompValueDegree_OnSubmit()
        {
            ValueDegree = -10;
            base.StateHasChanged();
        }

        private void InputSpinnerCompValueDegree_OnChange(double value)
        {
            Debug.WriteLine(value);
            ValueDegree = value;
            base.StateHasChanged();
        }

        #endregion Event Handler

        #region Protected Method

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                base.StateHasChanged();
            }
        }

        #endregion Protected Method
    }
}