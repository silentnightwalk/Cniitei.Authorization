# Cniitei.Authorization

Attempt to make an analogue of XACML for C# turned out to be unsuccessfull. I gave it a try, but it would be too difficult and senseless to finish.

See [XACML](http://wso2.com/library/articles/2011/10/understanding-xacml-policy-language-xacml-extended-assertion-markup-langue-part-1/) for more information.



# Example of usage


```javascript
    
    //Comming never (not soon).
    
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
    
    internal interface IClaimsProvider: IElement
    {
        IEnumerable<CniiteiClaimValue> GetClaims(CniiteiAuthorizationRequest request);
    }
    
```