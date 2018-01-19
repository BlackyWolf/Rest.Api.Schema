using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rest.Api.Schema.Documents
{
    public class Document : IDocument
    {
        private readonly IApiDescriptionGroupCollectionProvider apiExplorer;

        public Document(IApiDescriptionGroupCollectionProvider apiExplorer)
        {
            this.apiExplorer = apiExplorer ?? throw new ArgumentNullException(nameof(apiExplorer));
        }

        public object Create()
        {
            throw new NotImplementedException();
        }
    }
}
