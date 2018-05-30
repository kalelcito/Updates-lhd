Type.registerNamespace("Sys.Extended.UI"),Sys.Extended.UI.ToggleButtonBehavior=function(e){Sys.Extended.UI.ToggleButtonBehavior.initializeBase(this,[e]),this._idDecoration="_ToggleButton",this._imageWidth=null,this._imageHeight=null,this._uncheckedImageUrl=null,this._checkedImageUrl=null,this._disabledUncheckedImageUrl=null,this._disabledCheckedImageUrl=null,this._checkedImageOverUrl=null,this._uncheckedImageOverUrl=null,this._uncheckedImageAlternateText=null,this._checkedImageAlternateText=null,this._checkedImageOverAlternateText=null,this._uncheckedImageOverAlternateText=null,this._decoyElement=null,this._decoyElementClickHandler=null,this._checkChangedHandler=null,this._divContent=null,this._clickHandler=null,this._decoyElementMouseOverHandler=null,this._decoyElementMouseOutHandler=null},Sys.Extended.UI.ToggleButtonBehavior.prototype={initialize:function(){Sys.Extended.UI.ToggleButtonBehavior.callBaseMethod(this,"initialize");var e=this.get_element();this._divContent=document.createElement("div"),this._divContent.style.position="relative",this._decoyElement=document.createElement("a"),e.parentNode.insertBefore(this._divContent,e),this._decoyElement.id=e.id+this._idDecoration,this._decoyElement.href="",this._divContent.appendChild(this._decoyElement),e.style.visibility="hidden";var t=this._decoyElement.style;if(t.position="absolute",t.left="0px",t.top="0px",t.width=this._imageWidth+"px",t.height=this._imageHeight+"px",t.fontSize=this._imageHeight+"px",t.backgroundRepeat="no-repeat",this._onClick(),this._clickHandler=Function.createDelegate(this,this._onClick),this._checkChangedHandler=Function.createDelegate(this,this._onClick),this._decoyElementClickHandler=Function.createDelegate(this,this._onDecoyElementClick),this._decoyElementMouseOverHandler=Function.createDelegate(this,this._onDecoyElementMouseOver),this._decoyElementMouseOutHandler=Function.createDelegate(this,this._onDecoyElementMouseOut),$addHandler(e,"click",this._clickHandler),$addHandler(e,"change",this._checkChangedHandler),$addHandler(this._decoyElement,"click",this._decoyElementClickHandler),$addHandler(this._decoyElement,"mouseover",this._decoyElementMouseOverHandler),$addHandler(this._decoyElement,"mouseout",this._decoyElementMouseOutHandler),Sys.Browser.agent===Sys.Browser.InternetExplorer){var n=this._divContent.parentNode.getElementsByTagName("label");for(i=0;i<n.length;i++)e.id==n[i].htmlFor&&(n[i].htmlFor=e.id+this._idDecoration)}},dispose:function(){this._decoyElementClickHandler&&($removeHandler(this._decoyElement,"click",this._decoyElementClickHandler),this._decoyElementClickHandler=null),this._checkChangedHandler&&($removeHandler(this.get_element(),"change",this._checkChangedHandler),this._checkChangedHandler=null),this._clickHandler&&($removeHandler(this.get_element(),"click",this._clickHandler),this._clickHandler=null),this._decoyElementMouseOverHandler&&($removeHandler(this._decoyElement,"mouseover",this._decoyElementMouseOverHandler),this._decoyElementMouseOverHandler=null),this._decoyElementMouseOutHandler&&($removeHandler(this._decoyElement,"mouseout",this._decoyElementMouseOutHandler),this._decoyElementMouseOutHandler=null),Sys.Extended.UI.ToggleButtonBehavior.callBaseMethod(this,"dispose")},_onClick:function(){this.get_element().checked?(this._decoyElement.style.backgroundImage="url("+(this.get_element().disabled?this.get_disabledCheckedImageUrl():this._checkedImageUrl)+")",this._checkedImageAlternateText&&(this._decoyElement.title=this._checkedImageAlternateText)):(this._decoyElement.style.backgroundImage="url("+(this.get_element().disabled?this.get_disabledUncheckedImageUrl():this._uncheckedImageUrl)+")",this._uncheckedImageAlternateText&&(this._decoyElement.title=this._uncheckedImageAlternateText))},_onDecoyElementClick:function(e){return this.get_element().click(),e.preventDefault(),!1},_onDecoyElementMouseOver:function(e){var e=this.get_element();e&&!e.disabled&&(e.checked&&this._checkedImageOverUrl?(this._decoyElement.style.backgroundImage="url("+this._checkedImageOverUrl+")",this._checkedImageOverAlternateText&&(this._decoyElement.title=this._checkedImageOverAlternateText)):!e.checked&&this._uncheckedImageOverUrl&&(this._decoyElement.style.backgroundImage="url("+this._uncheckedImageOverUrl+")",this._uncheckedImageOverAlternateText&&(this._decoyElement.title=this._uncheckedImageOverAlternateText)))},_onDecoyElementMouseOut:function(e){this._onClick()},get_imageWidth:function(){return this._imageWidth},set_imageWidth:function(e){this._imageWidth!=e&&(this._imageWidth=e,this.raisePropertyChanged("imageWidth"))},get_ImageWidth:function(){return Sys.Extended.Deprecated("get_ImageWidth()","get_imageWidth()"),this.get_imageWidth()},set_ImageWidth:function(e){Sys.Extended.Deprecated("set_ImageWidth(value)","set_imageWidth(value)"),this.set_imageWidth(e)},get_imageHeight:function(){return this._imageHeight},set_imageHeight:function(e){this._imageHeight!=e&&(this._imageHeight=e,this.raisePropertyChanged("imageHeight"))},get_ImageHeight:function(){return Sys.Extended.Deprecated("get_ImageHeight()","get_imageHeight()"),this.get_imageHeight()},set_ImageHeight:function(e){Sys.Extended.Deprecated("set_ImageHeight(value)","set_imageHeight(value)"),this.set_imageHeight(e)},get_uncheckedImageUrl:function(){return this._uncheckedImageUrl},set_uncheckedImageUrl:function(e){this._uncheckedImageUrl!=e&&(this._uncheckedImageUrl=e,this.raisePropertyChanged("uncheckedImageUrl"))},get_UncheckedImageUrl:function(){return Sys.Extended.Deprecated("get_UncheckedImageUrl()","get_uncheckedImageUrl()"),this.get_uncheckedImageUrl()},set_UncheckedImageUrl:function(e){Sys.Extended.Deprecated("set_UncheckedImageUrl(value)","set_uncheckedImageUrl(value)"),this.set_uncheckedImageUrl(e)},get_checkedImageUrl:function(){return this._checkedImageUrl},set_checkedImageUrl:function(e){this._checkedImageUrl!=e&&(this._checkedImageUrl=e,this.raisePropertyChanged("checkedImageUrl"))},get_CheckedImageUrl:function(){return Sys.Extended.Deprecated("get_CheckedImageUrl()","get_checkedImageUrl()"),this.get_checkedImageUrl()},set_CheckedImageUrl:function(e){Sys.Extended.Deprecated("set_CheckedImageUrl(value)","set_checkedImageUrl(value)"),this.set_checkedImageUrl(e)},get_disabledUncheckedImageUrl:function(){return void 0!=this._disabledUncheckedImageUrl?this._disabledUncheckedImageUrl:this._uncheckedImageUrl},set_disabledUncheckedImageUrl:function(e){this._disabledUncheckedImageUrl!=e&&(this._disabledUncheckedImageUrl=e,this.raisePropertyChanged("disabledUncheckedImageUrl"))},get_DisabledUncheckedImageUrl:function(){return Sys.Extended.Deprecated("get_DisabledUncheckedImageUrl()","get_disabledUncheckedImageUrl()"),this.get_disabledUncheckedImageUrl()},set_DisabledUncheckedImageUrl:function(e){Sys.Extended.Deprecated("set_DisabledUncheckedImageUrl(value)","set_disabledUncheckedImageUrl(value)"),this.set_disabledUncheckedImageUrl(e)},get_disabledCheckedImageUrl:function(){return void 0!=this._disabledUncheckedImageUrl?this._disabledCheckedImageUrl:this._checkedImageUrl},set_disabledCheckedImageUrl:function(e){this._disabledCheckedImageUrl!=e&&(this._disabledCheckedImageUrl=e,this.raisePropertyChanged("disabledCheckedImageUrl"))},get_DisabledCheckedImageUrl:function(){return Sys.Extended.Deprecated("get_DisabledCheckedImageUrl()","get_disabledCheckedImageUrl()"),this.get_disabledCheckedImageUrl()},set_DisabledCheckedImageUrl:function(e){Sys.Extended.Deprecated("set_DisabledCheckedImageUrl(value)","set_disabledCheckedImageUrl(value)"),this.set_disabledCheckedImageUrl(e)},get_checkedImageOverUrl:function(){return this._checkedImageOverUrl},set_checkedImageOverUrl:function(e){this._checkedImageOverUrl!=e&&(this._checkedImageOverUrl=e,this.raisePropertyChanged("checkedImageOverUrl"))},get_CheckedImageOverUrl:function(){return Sys.Extended.Deprecated("get_CheckedImageOverUrl()","get_checkedImageOverUrl()"),this.get_checkedImageOverUrl()},set_CheckedImageOverUrl:function(e){Sys.Extended.Deprecated("set_CheckedImageOverUrl(value)","set_checkedImageOverUrl(value)"),this.set_checkedImageOverUrl(e)},get_uncheckedImageOverUrl:function(){return this._uncheckedImageOverUrl},set_uncheckedImageOverUrl:function(e){this._uncheckedImageOverUrl!=e&&(this._uncheckedImageOverUrl=e,this.raisePropertyChanged("uncheckedImageOverUrl"))},get_UncheckedImageOverUrl:function(){return Sys.Extended.Deprecated("get_UncheckedImageOverUrl()","get_uncheckedImageOverUrl()"),this.get_uncheckedImageOverUrl()},set_UncheckedImageOverUrl:function(e){Sys.Extended.Deprecated("set_UncheckedImageOverUrl(value)","set_uncheckedImageOverUrl(value)"),this.set_uncheckedImageOverUrl(e)},get_uncheckedImageAlternateText:function(){return this._uncheckedImageAlternateText},set_uncheckedImageAlternateText:function(e){this._uncheckedImageAlternateText!=e&&(this._uncheckedImageAlternateText=e,this.raisePropertyChanged("uncheckedImageAlternateText"))},get_UncheckedImageAlternateText:function(){return Sys.Extended.Deprecated("get_UncheckedImageAlternateText()","get_uncheckedImageAlternateText()"),this.get_uncheckedImageAlternateText()},set_UncheckedImageAlternateText:function(e){Sys.Extended.Deprecated("set_UncheckedImageAlternateText(value)","set_uncheckedImageAlternateText(value)"),this.set_uncheckedImageAlternateText(e)},get_checkedImageAlternateText:function(){return this._checkedImageAlternateText},set_checkedImageAlternateText:function(e){this._checkedImageAlternateText!=e&&(this._checkedImageAlternateText=e,this.raisePropertyChanged("checkedImageAlternateText"))},get_CheckedImageAlternateText:function(){return Sys.Extended.Deprecated("get_CheckedImageAlternateText()","get_checkedImageAlternateText()"),this.get_checkedImageAlternateText()},set_CheckedImageAlternateText:function(e){Sys.Extended.Deprecated("set_CheckedImageAlternateText(value)","set_checkedImageAlternateText(value)"),this.set_checkedImageAlternateText(e)},get_checkedImageOverAlternateText:function(){return this._checkedImageOverAlternateText},set_checkedImageOverAlternateText:function(e){this._checkedImageOverAlternateText!=e&&(this._checkedImageOverAlternateText=e,this.raisePropertyChanged("checkedImageOverAlternateText"))},get_CheckedImageOverAlternateText:function(){return Sys.Extended.Deprecated("get_CheckedImageOverAlternateText()","get_checkedImageOverAlternateText()"),this.get_checkedImageOverAlternateText()},set_CheckedImageOverAlternateText:function(e){Sys.Extended.Deprecated("set_CheckedImageOverAlternateText(value)","set_checkedImageOverAlternateTet(value)"),this.set_checkedImageOverAlternateText(e)},get_uncheckedImageOverAlternateText:function(){return this._uncheckedImageOverAlternateText},set_uncheckedImageOverAlternateText:function(e){this._uncheckedImageOverAlternateText!=e&&(this._uncheckedImageOverAlternateText=e,this.raisePropertyChanged("uncheckedImageOverAlternateText"))},get_UncheckedImageOverAlternateText:function(){return Sys.Extended.Deprecated("get_UncheckedImageOverAlternateText()","get_uncheckedImageOverAlternateText()"),this.get_uncheckedImageOverAlternateText()},set_UncheckedImageOverAlternateText:function(e){Sys.Extended.Deprecated("set_UncheckedImageOverAlternateText(value)","set_uncheckedImageOverAlternateTet(value)"),this.set_uncheckedImageOverAlternateText(e)}},Sys.Extended.UI.ToggleButtonBehavior.registerClass("Sys.Extended.UI.ToggleButtonBehavior",Sys.Extended.UI.BehaviorBase);