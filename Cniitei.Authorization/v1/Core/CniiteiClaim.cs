using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cniitei.Authorization.v1
{
    [Serializable]
    public class CniiteiClaimDto
    {
        public string ClaimType { get; set; }
        public string Value { get; set; }
        public string ValueType { get; set; }
        public string Issuer { get; set; }
        public string OriginalIssuer { get; set; }
        public string Subject { get; set; }
        public List<CniiteiClaimPropertyDto> Properties { get; set; } = new List<CniiteiClaimPropertyDto>();
    }

    public class CniiteiClaim
    {
        public string ClaimType { get; }
        public string Value { get; }
        public string ValueType { get; }
        public string Issuer { get; }
        public string OriginalIssuer { get; }
        public string Subject { get; }
        public IEnumerable<CniiteiClaimProperty> Properties { get; } = Enumerable.Empty<CniiteiClaimProperty>();

        public CniiteiClaim(CniiteiClaimDto claimDto)
            : this(claimDto.ClaimType, claimDto.Value, claimDto.ValueType, claimDto.Issuer, claimDto.OriginalIssuer, claimDto.Subject)
        {
            if (claimDto.Properties != null)
            {
                var props = new List<CniiteiClaimProperty>();

                foreach (var propDto in claimDto.Properties)
                {
                    if (!String.IsNullOrWhiteSpace(propDto.Key) && !String.IsNullOrWhiteSpace(propDto.Value))
                    {
                        props.Add(new CniiteiClaimProperty(propDto.Key, propDto.Value));
                    }
                }

                Properties = props;
            }
        }

        public CniiteiClaim(
            string claimType, 
            string value, 
            string valueType, 
            string issuer, 
            string originalIssuer,
            string subject,
            string claimPropertyKey,
            string claimPropertyValue
            )
        {
            if (
                String.IsNullOrWhiteSpace(claimType) ||
                String.IsNullOrWhiteSpace(value) ||
                String.IsNullOrWhiteSpace(valueType)
               )
            {
                throw new ArgumentException("Each claim must have non empty claimType,value,valueType. (c) CniiteiClaim() constructor.");
            }

            ClaimType = claimType;
            Value = value;
            ValueType = valueType;
            Issuer = issuer;
            OriginalIssuer = originalIssuer;
            Subject = subject;

            if (!String.IsNullOrWhiteSpace(claimPropertyKey) && !String.IsNullOrWhiteSpace(claimPropertyValue))
            {
                var props = new List<CniiteiClaimProperty>();
                props.Add(new CniiteiClaimProperty(claimPropertyKey, claimPropertyValue));
                Properties = props;
            }

            
        }

        public CniiteiClaim(
            string claimType,
            string value,
            string valueType,
            string issuer,
            string originalIssuer,
            string subject
            ) :this(claimType, value, valueType, issuer, originalIssuer, subject, claimPropertyKey: (string)null, claimPropertyValue: (string)null)
        {

        }

        public CniiteiClaim(
            string claimType,
            string value,
            string valueType,
            string issuer,
            string originalIssuer
            ) : this(claimType, value, valueType, issuer, originalIssuer, subject: (string)null)
        {

        }

        public CniiteiClaim(
            string claimType,
            string value,
            string valueType,
            string issuer
            ) : this(claimType, value, valueType, issuer, originalIssuer: (string)null)
        {

        }

        public CniiteiClaim(
            string claimType,
            string value,
            string valueType
            ) : this(claimType, value, valueType, issuer: (string)null)
        {

        }

        public CniiteiClaim(
            string claimType,
            string value
            ) : this(claimType, value, valueType: CniiteiValueTypes.String)
        {

        }
    }
}
