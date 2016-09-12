# Cniitei.Authorization

Attempt to make an access control system for .Net 4.0+. An alternative for XACML-based access control systems for .Net, but simpler. Much is taken from XACML concept. At the moment this project is under development, probably, just a prototype.

The basic idea is that the authoriZation service uses a decision tree to give the answer of either permit or deny. This tree consists of elements, which are either lower level decision makers or other functional items.

It is, probably, a good idea to use fluent notation to build this desision tree (AuthirizationModel). At least for testing purposes. Later on, it is, probably, a good idea to facilitize json serialization of this tree. Finally, it would be perfect to make an online service with user-friendly editing tool for such authorization models (or decision trees - same thing).  

Again, now it's only under development.

See [XACML](http://wso2.com/library/articles/2011/10/understanding-xacml-policy-language-xacml-extended-assertion-markup-langue-part-1/) for more information.



# Example of usage


```javascript
    
    //Comming soon.
    
```

# Authorization model elements (general idea)


```cs

    public interface IAuthorizationModel: IElement
    {
        string ProjectName { get; }
        
        IDefinitions Definitions { get; }
        IPolicySet { get; }
        
        bool CheckAccess(CniiteiAuthorizationRequest request);
        void ThrowIfNoAccess(CniiteiAuthorizationRequest request);
    }
   
```
```cs
    
    internal interface IDefinitions: IElement
    {
        IEnumerable<IFact> DefinedFacts { get; }
        IEnumerable<IRule> DefinedRules { get; }
        IEnumerable<IPolicy> DefinedPolicies { get; }
    }
  
```
```cs  
    
    public interface IFact: IElement
    {
        bool CanSay(CniiteiAuthorizationRequest request);
    }
    
```
```cs
    
    internal interface IRule: IPermissionDecider, IElement
    {
        bool Effect { get; }
        IConditionCriterion Condition { get; }
        ITargetCriterion Target { get; }
    }
    
```
```cs
    
    internal interface IPolicy: IPermissionDecider, IElement
    {
        IEnumerable<IObligation> Obligations { get; }
        ITargetCriterion Target { get; }
        IEnumerable<IPermissionDecider> PermissionDeciders { get; }
        ICombiningAlgorithm CombiningAlgorithm { get; }
    }
    
```
```cs
    
    internal interface IPolicySet: IElement
    {
        IEnumerable<IPolicy> Policies { get; }
        ICombiningAlgorithm PolicyCombiningAlgorithm { get; }
        Decision MakeDecision(CniiteiAuthorizationRequest request);
    }
    
```
```cs
    
    internal interface IPermissionDecider: IElement
    {
        Decision MakeDecision(CniiteiAuthorizationRequest request);
    }
    
```
```cs
    
    internal interface ICombiningAlgorithm: IElement
    {
        Decision MakeDecision(CniiteiAuthorizationRequest request, IEnumerable<IPermissionDecider> permissionDeciders);
    }
    
```
```cs
    
    internal interface ITargetCriterion: IFact, IElement
    {
        IFact Fact { get; }
    }

```
```cs

    internal interface IConditionCriterion : IFact, IElement
    {
        IFact Fact { get; }
    }
    
```
```cs
    
    public interface IObligation: IElement
    {
        void Fulfill(CniiteiAuthorizationRequest request, string policyId, DecisionValue policyDecision);
    }
    
```
```cs
    
    internal interface ICompositeFactFunction: IElement
    {
        bool CanSay(CniiteiAuthorizationRequest request, params IFact[] parameters);
    }
    
```
```cs
    
    internal interface IClaimBasedFactFunction: IElement
    {
        bool CanSay(CniiteiAuthorizationRequest request, params IClaimsProvider[] parameters);
    }
    
```
```cs
    
    internal interface IClaimsProvider: IElement
    {
        IEnumerable<CniiteiClaimValue> GetClaims(CniiteiAuthorizationRequest request);
    }
    
```