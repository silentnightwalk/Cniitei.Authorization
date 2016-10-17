using Cniitei.Authorization.v1.Core;
using DryIoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cniitei.Authorization.v1.Elements
{
    public abstract class TwoProvidersFact : IFact
    {
        public List<IClaimValuesProvider> TwoClaimValuesProviders { get; internal set; } = new List<IClaimValuesProvider>();

        public abstract bool CanSay(CniiteiAuthorizationRequest request);

        public void Validate()
        {
            if (TwoClaimValuesProviders == null || TwoClaimValuesProviders.Count != 2)
            {
                throw new Exception($"{this.GetType().Name} must have 2 claim providers");
            }
        }
    }

    public class TwoProvidersFactBuilder<TTwoProvidersFact, TParentBuilder> : FluentElmBuilder<TTwoProvidersFact, TParentBuilder>
        where TParentBuilder : ElmBuilderBase
        where TTwoProvidersFact : TwoProvidersFact, new()
    {
        public TwoProvidersFactBuilder(TParentBuilder parentBuilder)
            : base(ElmTypes.ClaimsEqualFact, parentBuilder)
        {

        }

        public ActionClaimValuesProviderBuilder<TwoProvidersFactBuilder<TTwoProvidersFact, TParentBuilder>> BeginActionClaimValuesProvider()
        {
            var childBuilder = new ActionClaimValuesProviderBuilder<TwoProvidersFactBuilder<TTwoProvidersFact, TParentBuilder>>(this);

            Result.TwoClaimValuesProviders.Add(childBuilder.GetEarlyResult());

            return childBuilder;
        }

        public AllClaimValuesProviderBuilder<TwoProvidersFactBuilder<TTwoProvidersFact, TParentBuilder>> BeginAllClaimValuesProvider()
        {
            var childBuilder = new AllClaimValuesProviderBuilder<TwoProvidersFactBuilder<TTwoProvidersFact, TParentBuilder>>(this);

            Result.TwoClaimValuesProviders.Add(childBuilder.GetEarlyResult());

            return childBuilder;
        }

        public ResourceClaimValuesProviderBuilder<TwoProvidersFactBuilder<TTwoProvidersFact, TParentBuilder>> BeginResourceClaimValuesProvider()
        {
            var childBuilder = new ResourceClaimValuesProviderBuilder<TwoProvidersFactBuilder<TTwoProvidersFact, TParentBuilder>>(this);

            Result.TwoClaimValuesProviders.Add(childBuilder.GetEarlyResult());

            return childBuilder;
        }

        public ClaimValueProviderBuilder<TwoProvidersFactBuilder<TTwoProvidersFact, TParentBuilder>> BeginClaimValuesProvider()
        {
            var childBuilder = new ClaimValueProviderBuilder<TwoProvidersFactBuilder<TTwoProvidersFact, TParentBuilder>>(this);

            Result.TwoClaimValuesProviders.Add(childBuilder.GetEarlyResult());

            return childBuilder;
        }

        public TwoProvidersFactBuilder<TTwoProvidersFact, TParentBuilder> SetCustomClaimValuesProvider(
            string uniqueKey,
            IClaimValuesProvider claimValuesProvider
            )
        {
            try
            {
                AuthorizationLogicContainer.UseInstance<IClaimValuesProvider>(
                    claimValuesProvider,
                    serviceKey: $"{nameof(IClaimValuesProvider)}_{uniqueKey}"
                    );

                Result.TwoClaimValuesProviders.Add(claimValuesProvider);
            }
            catch (Exception exn)
            {
                throw CreateAuthorizationModelBuildingException(exn, $"registering in container {nameof(IClaimValuesProvider)} with key {uniqueKey}");
            }

            return this;
        }

        public TwoProvidersFactBuilder<TTwoProvidersFact, TParentBuilder> UseExistingCustomClaimValuesProvider(
            string uniqueKey
            )
        {
            try
            {
                var resolvedProvider = AuthorizationLogicContainer.Resolve<IClaimValuesProvider>(
                    serviceKey: $"{nameof(IClaimValuesProvider)}_{uniqueKey}"
                    );

                Result.TwoClaimValuesProviders.Add(resolvedProvider);
            }
            catch (Exception exn)
            {
                throw CreateAuthorizationModelBuildingException(exn, $"resolving from container {nameof(IClaimValuesProvider)} with key {uniqueKey}");
            }

            return this;
        }
    }
}
