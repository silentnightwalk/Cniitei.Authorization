using DryIoc;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Cniitei.Authorization.v1.Core
{
    /// <summary>
    /// Generic base abstract class for builder of a decision tree element
    /// </summary>
    /// <typeparam name="TElement">decision tree element type</typeparam>
    /// <typeparam name="TParentBuilder">parent builder class type</typeparam>
    public abstract class FluentElmBuilder<TElement,TParentBuilder>: ElmBuilderBase
        where TElement : class, IElement, new()
        where TParentBuilder : ElmBuilderBase
    {
        internal override IElement Element { get; set; }
        protected TElement Result { get { return Element as TElement; } }
        public TElement GetEarlyResult() { return Result; }

        internal TParentBuilder Parent
        {
            get { return ParentBuilder as TParentBuilder; }
        }

        public FluentElmBuilder(string elmType, TParentBuilder parentBuilder)
            :base(elmType, parentBuilder)
        {
            Element = new TElement();
        }

        /// <summary>
        /// builds element
        /// </summary>
        /// <returns>parent builder for fluent pattern purposes</returns>
        public TParentBuilder End()
        {
            var label = $"`{this.ElmType}` validation";
            try
            {
                Result.Validate();

                //register definitions
                if (IsDefinition)
                {
                    label = $"End() method, registering definition of `{this.ElmType}`";

                    if (String.IsNullOrWhiteSpace(this.UniqueKeyIfExists))
                    {
                        throw new Exception($"`Unique Key` property of this `{this.ElmType}` definition element must be set");
                    }
                    AuthorizationLogicContainer.RegisterInstance(
                        serviceType: typeof(TElement),
                        instance: Result,
                        serviceKey: this.UniqueKeyIfExists
                        );
                }

                return Parent;
            }
            catch (CniiteiAuthorizationModelBuildingException customExn)
            {
                throw customExn;
            }
            catch (Exception exn)
            {
                throw CreateAuthorizationModelBuildingException(exn, label);
            }
        }
    }

    // -------- -------- -------- -------- -------- -------- -------- --------

    /// <summary>
    /// Base abstract class for builder of a decision tree element
    /// </summary>
    public abstract class ElmBuilderBase
    {
        // -------- major properties --------

        internal virtual IElement Element { get; set; }
        internal ElmBuilderBase ParentBuilder { get; private set; }
        internal Container AuthorizationLogicContainer { get; private set; }
        internal IdentificationManager IdentificationManager { get; private set; }

        // -------- info properties --------

        internal string ElmType { get; }
        internal virtual bool IsDefinition { get; } = false;
        internal int GlobalIndex { get; }
        internal int? LocalIndex { get; }
        internal string UniqueKeyIfExists { get; set; }

        // -------- constructors --------

        internal ElmBuilderBase(string elmType, ElmBuilderBase parentBuilder, IElement element)
            : this(elmType, parentBuilder, localIndex: null)
        {
            //this is most common constructor
            Element = element;
        }

        public ElmBuilderBase(string elmType, ElmBuilderBase parentBuilder = null, int? localIndex = null)
            :this(parentBuilder, localIndex)
        {
            ElmType = elmType;
            GlobalIndex = IdentificationManager.NextGlobalIndex();
        }

        internal ElmBuilderBase(ElmDto elmDto, ElmBuilderBase parentBuilder = null, int? localIndex = null)
            : this(parentBuilder, localIndex)
        {
            ElmType = elmDto.ElmType;
            GlobalIndex = elmDto.Id;
        }

        private ElmBuilderBase(ElmBuilderBase parentBuilder = null, int? localIndex = null)
        {
            ParentBuilder = parentBuilder;

            if (ParentBuilder == null)
            {
                AuthorizationLogicContainer = new DryIoc.Container();
                IdentificationManager = new IdentificationManager();
                LocalIndex = localIndex ?? 1;
            }
            else
            {
                AuthorizationLogicContainer = ParentBuilder.AuthorizationLogicContainer;
                IdentificationManager = ParentBuilder.IdentificationManager.Another();
                LocalIndex = localIndex ?? ParentBuilder.IdentificationManager.NextLocalIndex();
            }
        }

        // -------- major methods --------

        /// <summary>
        /// Builds element from its dto
        /// </summary>
        internal IElement BuildFromDto(Container containerWithBuilders, Stack<ElmDto> dtos)
        {
            //TODO: Possible to do serilization to and from dto
            throw new NotImplementedException();

            var label = $"building from dto, popping next dto";
            try
            {
                var dto = dtos.Pop();

                label = $"popped dto is `{dto.ElmType}`, initializing element";

                //TODO: Element.FromDto
                //Element.FromDto(dto);

                while (dtos.Peek()?.ParentId == dto.Id)
                {
                    var elmType = dtos.Peek()?.ElmType;

                    label = $"resolving builder for `{elmType}`";
                    var childBuilder = containerWithBuilders
                        .Resolve<ElmBuilderBase>(elmType);

                    label = $"adding child to `{dto.ElmType}`";

                    //TODO: Element.AddChild
                    //Element.AddChild(
                    //    childBuilder.BuildFromDto(containerWithBuilders, dtos)
                    //    );
                }

                label = $"validating `{dto.ElmType}`";
                Element.Validate();

                return Element;
            }
            catch (CniiteiAuthorizationModelBuildingException customExn)
            {
                throw customExn;
            }
            catch (Exception exn)
            {
                throw CreateAuthorizationModelBuildingException(exn, label);
            }
        }

        /// <summary>
        /// creates special informative exception
        /// </summary>
        protected CniiteiAuthorizationModelBuildingException CreateAuthorizationModelBuildingException(Exception innerException, string userMethodInfo = "")
        {
            ElmBuilderBase elmInfo = this;
            var traceList = new List<ModelBuildingErrorSource>();

            while (elmInfo != null)
            {
                traceList.Add(elmInfo.CreateErrorSource());
                elmInfo = elmInfo.ParentBuilder;
            }

            traceList.Reverse();

            return new CniiteiAuthorizationModelBuildingException(innerException, traceList, userMethodInfo);
        }

    }
}
