using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
            return A();

            IEnumerable<object> A()
            {
                foreach (var item in apiExplorer.ApiDescriptionGroups.Items)
                {
                    yield return new
                    {
                        item.GroupName,
                        Items = B(item)
                    };
                }
            }

            IEnumerable<object> B(ApiDescriptionGroup group)
            {
                foreach (var item in group.Items)
                {
                    yield return new
                    {
                        ActionDescriptor = C(item),
                        item.GroupName,
                        item.HttpMethod,
                        //ParameterDescriptions = D(item),
                        item.Properties,
                        item.RelativePath,
                        SupportedRequestFormats = E(item),
                        SupportedResponseTypes = F(item),
                    };
                }
            }

            object C(ApiDescription description)
            {
                var descriptor = description.ActionDescriptor;

                return new
                {
                    //ActionConstraints = G(descriptor),
                    //AttributeRouteInfo = H(descriptor),
                    //BoundProperties = I(descriptor),
                    descriptor.DisplayName,
                    //FilterDescriptors = J(descriptor),
                    descriptor.Id,
                    //Parameters = K(descriptor),
                    descriptor.Properties,
                    descriptor.RouteValues
                };
            }

            IEnumerable<object> D(ApiDescription description)
            {
                foreach (var descriptor in description.ParameterDescriptions)
                {
                    yield return new
                    {
                        ModelMetadata = ModelMetadata(descriptor.ModelMetadata),
                        descriptor.Name,
                        ParameterDescriptor = M(descriptor),
                        //RouteInfo = N(descriptor),
                        //Source = O(descriptor),
                        descriptor.Type
                    };
                }
            }

            IEnumerable<string> E(ApiDescription description)
            {
                foreach (var item in description.SupportedRequestFormats)
                {
                    yield return item.MediaType;
                }
            }

            IEnumerable<object> F(ApiDescription description)
            {
                foreach (var item in description.SupportedResponseTypes)
                {
                    yield return new
                    {
                        item.ApiResponseFormats,
                        ModelMetadata = ModelMetadata(item.ModelMetadata),
                        item.StatusCode,
                        item.Type
                    };
                }
            }

            IEnumerable<object> G(ActionDescriptor descriptor)
            {
                if (descriptor == null)
                {
                    yield return null;
                }
                else
                {
                    foreach (var item in descriptor.ActionConstraints)
                    {
                        yield return new
                        {
                            item
                        };
                    }
                }
            }

            object H(ActionDescriptor descriptor)
            {
                if (descriptor == null) return null;

                var info = descriptor.AttributeRouteInfo;

                return new
                {
                    info.Name,
                    info.Order,
                    info.SuppressLinkGeneration,
                    info.SuppressPathMatching,
                    info.Template
                };
            }

            IEnumerable<object> I(ActionDescriptor descriptor)
            {
                if (descriptor == null)
                {
                    yield return null;
                }
                else
                {
                    foreach (var property in descriptor.BoundProperties)
                    {
                        yield return new
                        {
                            //property.BindingInfo,
                            property.Name,
                            property.ParameterType
                        };
                    }
                }
            }

            IEnumerable<object> J(ActionDescriptor descriptor)
            {
                if (descriptor == null)
                {
                    yield return null;
                }
                else
                {
                    foreach (var filter in descriptor.FilterDescriptors)
                    {
                        yield return new
                        {
                            //filter.Filter,
                            filter.Order,
                            filter.Scope
                        };
                    }
                }
            }

            IEnumerable<object> K(ActionDescriptor descriptor)
            {
                if (descriptor == null)
                {
                    yield return null;
                }
                else
                {
                    foreach (var parameter in descriptor.Parameters)
                    {
                        yield return new
                        {
                            //parameter.BindingInfo,
                            parameter.Name,
                            parameter.ParameterType
                        };
                    }
                }
            }

            object ModelMetadata(ModelMetadata model)
            {
                if (model == null) return null;

                return new
                {
                    model.AdditionalValues,
                    model.BinderModelName,
                    model.BinderType,
                    //model.BindingSource,
                    //ContainerMetadata = ModelMetadata(model.ContainerMetadata),
                    model.ContainerType,
                    model.ConvertEmptyStringToNull,
                    model.DataTypeName,
                    model.Description,
                    model.DisplayFormatString,
                    model.DisplayName,
                    model.EditFormatString,
                    //ElementMetadata = ModelMetadata(model.ElementMetadata),
                    model.ElementType,
                    model.EnumGroupedDisplayNamesAndValues,
                    model.EnumNamesAndValues,
                    model.HasNonDefaultEditFormat,
                    model.HideSurroundingHtml,
                    model.HtmlEncode,
                    model.IsBindingAllowed,
                    model.IsBindingRequired,
                    model.IsCollectionType,
                    model.IsComplexType,
                    model.IsEnum,
                    model.IsEnumerableType,
                    model.IsFlagsEnum,
                    model.IsNullableValueType,
                    model.IsReadOnly,
                    model.IsReferenceOrNullableType,
                    model.IsRequired,
                    model.MetadataKind,
                    model.ModelType,
                    model.NullDisplayText,
                    model.Order,
                    model.Placeholder,
                    //model.Properties,
                    model.PropertyName,
                    model.ShowForDisplay,
                    model.ShowForEdit,
                    model.SimpleDisplayProperty,
                    model.TemplateHint,
                    model.UnderlyingOrModelType,
                    model.ValidateChildren,
                    model.ValidatorMetadata
                };
            }

            object M(ApiParameterDescription description)
            {
                if (description == null) return null;

                var descriptor = description.ParameterDescriptor;

                return new
                {
                    descriptor.Name,
                    descriptor.ParameterType
                };
            }
        }
    }
}
