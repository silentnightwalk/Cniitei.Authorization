using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cniitei.Authorization.v1.Core;
using DryIoc;

namespace Cniitei.Authorization.v1.Elements
{
    public class ClaimValueCollectionsEqualFact: IFact
    {
        public List<IClaimValuesProvider> TwoClaimValuesProviders { get; internal set; }  = new List<IClaimValuesProvider>();

        public bool CanSay(CniiteiAuthorizationRequest request)
        {
            //compare two collections of claims

            //TODO: think of a more effective way

            //left and right claim sequence 
            var left = TwoClaimValuesProviders[0].GetClaimValues(request)?.ToArray() ?? new CniiteiClaimValue[] { };
            var right = TwoClaimValuesProviders[1].GetClaimValues(request)?.ToArray() ?? new CniiteiClaimValue[] { };

            if (left.Length != right.Length)
                return false;

            if (left.Length == 0 && right.Length == 0)
                return true;

            //group by value type
            var leftGroupped = left.GroupBy(c => c.ValueType);
            var rightGroupped = right.GroupBy(c => c.ValueType);

            if (leftGroupped.Count() != rightGroupped.Count())
                return false;

            //order groups by value type and convert to key value pairs where key is count of elements in group
            var leftDoubleGroupped = leftGroupped.OrderBy(g => g.Key).Select(g => new KeyValuePair<int,IEnumerable<CniiteiClaimValue>>(g.Count(),g)).ToArray();
            var rightDoubleGroupped = rightGroupped.OrderBy(g => g.Key).Select(g => new KeyValuePair<int, IEnumerable<CniiteiClaimValue>>(g.Count(), g)).ToArray();

            for (int k = 0; k <= leftDoubleGroupped.Length - 1; k++)
            {
                //key is count of elements in group
                if (leftDoubleGroupped[k].Key != rightDoubleGroupped[k].Key)
                    return false;

                //leftDoubleGroupped[k].Value is claim sequence
                //convert claims to their values and order the sequence of the group
                var leftGroup = leftDoubleGroupped[k].Value.Select(c => c.Value).OrderBy(v => v).ToArray();
                var rightGroup = rightDoubleGroupped[k].Value.Select(c => c.Value).OrderBy(v => v).ToArray();

                //compare ordered sequences for equality
                if (!leftGroup.SequenceEqual(rightGroup))
                    return false;
            }

            return true;
        }

        public void Validate()
        {
            if (TwoClaimValuesProviders == null || TwoClaimValuesProviders.Count != 2)
            {
                throw new Exception($"{nameof(ClaimValueCollectionsEqualFact)} must have 2 claim providers");
            } 
        }
    }

    public class ClaimValueCollectionsEqualFactBuilder<TParentBuilder> : FluentElmBuilder<ClaimValueCollectionsEqualFact, TParentBuilder>
        where TParentBuilder : ElmBuilderBase
    {
        public ClaimValueCollectionsEqualFactBuilder(TParentBuilder parentBuilder) 
            : base(ElmTypes.ClaimsEqualFact, parentBuilder)
        {

        }

        public ActionClaimValuesProviderBuilder<ClaimValueCollectionsEqualFactBuilder<TParentBuilder>> BeginActionClaimValuesProvider()
        {
            var childBuilder = new ActionClaimValuesProviderBuilder<ClaimValueCollectionsEqualFactBuilder<TParentBuilder>>(this);

            Result.TwoClaimValuesProviders.Add(childBuilder.GetEarlyResult());

            return childBuilder;
        }

        public AllClaimValuesProviderBuilder<ClaimValueCollectionsEqualFactBuilder<TParentBuilder>> BeginAllClaimValuesProvider()
        {
            var childBuilder = new AllClaimValuesProviderBuilder<ClaimValueCollectionsEqualFactBuilder<TParentBuilder>>(this);

            Result.TwoClaimValuesProviders.Add(childBuilder.GetEarlyResult());

            return childBuilder;
        }

        public ResourceClaimValuesProviderBuilder<ClaimValueCollectionsEqualFactBuilder<TParentBuilder>> BeginResourceClaimValuesProvider()
        {
            var childBuilder = new ResourceClaimValuesProviderBuilder<ClaimValueCollectionsEqualFactBuilder<TParentBuilder>>(this);

            Result.TwoClaimValuesProviders.Add(childBuilder.GetEarlyResult());

            return childBuilder;
        }

        public ClaimValueProviderBuilder<ClaimValueCollectionsEqualFactBuilder<TParentBuilder>> BeginClaimValuesProvider()
        {
            var childBuilder = new ClaimValueProviderBuilder<ClaimValueCollectionsEqualFactBuilder<TParentBuilder>>(this);

            Result.TwoClaimValuesProviders.Add(childBuilder.GetEarlyResult());

            return childBuilder;
        }

        public ClaimValueCollectionsEqualFactBuilder<TParentBuilder> SetCustomClaimValuesProvider(
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

        public ClaimValueCollectionsEqualFactBuilder<TParentBuilder> UseExistingCustomClaimValuesProvider(
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
