using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace FreeTime.Web.Application.Providers
{
    public class CustomMetaDataProvider : IMetadataDetailsProvider, IDisplayMetadataProvider
    {
        public void CreateDisplayMetadata(DisplayMetadataProviderContext context)
        {
            if (context.Key.MetadataKind == ModelMetadataKind.Property)
                context.DisplayMetadata.ConvertEmptyStringToNull = false;
        }
    }
}
