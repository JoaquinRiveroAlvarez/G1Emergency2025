namespace G1Emergency2025.Server.Client.Shared
{
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Forms;
    using Microsoft.AspNetCore.Components.Rendering;

    public class InputSelectMultiple<TValue> : InputBase<List<TValue>>
    {
        protected override bool TryParseValueFromString(string? value, out List<TValue> result, out string? validationErrorMessage)
        {
            // Blazor no usa esta conversión directamente porque el control es multiple.
            result = new List<TValue>();
            validationErrorMessage = null;
            return true;
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "select");
            builder.AddMultipleAttributes(1, AdditionalAttributes);
            builder.AddAttribute(2, "multiple", "multiple");
            builder.AddAttribute(3, "class", CssClass);
            builder.AddAttribute(4, "onchange", EventCallback.Factory.CreateBinder<string[]>(
                this,
                __values => CurrentValue = __values.Select(v => (TValue)Convert.ChangeType(v, typeof(TValue))).ToList(),
                CurrentValue?.Select(v => v?.ToString()).ToArray() ?? Array.Empty<string>()
            ));
            builder.AddContent(5, ChildContent);
            builder.CloseElement();
        }

        [Parameter] public RenderFragment? ChildContent { get; set; }
    }
}
