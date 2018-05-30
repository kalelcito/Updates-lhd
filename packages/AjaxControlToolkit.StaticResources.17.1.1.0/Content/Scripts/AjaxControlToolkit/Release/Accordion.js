Type.registerNamespace("Sys.Extended.UI"),Sys.Extended.UI.AutoSize=function(){throw Error.invalidOperation()},Sys.Extended.UI.AutoSize.prototype={None:0,Fill:1,Limit:2},Sys.Extended.UI.AutoSize.registerEnum("Sys.Extended.UI.AutoSize",!1),Sys.Extended.UI.AccordionSelectedIndexChangeEventArgs=function(e,t){Sys.Extended.UI.AccordionSelectedIndexChangeEventArgs.initializeBase(this),this._oldIndex=e,this._selectedIndex=t},Sys.Extended.UI.AccordionSelectedIndexChangeEventArgs.prototype={get_oldIndex:function(){return this._oldIndex},set_oldIndex:function(e){this._oldIndex=e},get_selectedIndex:function(){return this._selectedIndex},set_selectedIndex:function(e){this._selectedIndex=e}},Sys.Extended.UI.AccordionSelectedIndexChangeEventArgs.registerClass("Sys.Extended.UI.AccordionSelectedIndexChangeEventArgs",Sys.CancelEventArgs),Sys.Extended.UI.AccordionBehavior=function(e){Sys.Extended.UI.AccordionBehavior.initializeBase(this,[e]),this._selectedIndex=0,this._panes=[],this._fadeTransitions=!1,this._duration=.25,this._framesPerSecond=30,this._autoSize=Sys.Extended.UI.AutoSize.None,this._requireOpenedPane=!0,this._suppressHeaderPostbacks=!1,this._headersSize=0,this._headerClickHandler=null,this._headerCssClass="",this._headerSelectedCssClass="",this._resizeHandler=null,this._isIE8InStandardMode=Sys.Browser.agent==Sys.Browser.InternetExplorer&&Sys.Browser.version>7&&0!=Sys.Browser.documentMode,this._paneHeaderClassNames=[]},Sys.Extended.UI.AccordionBehavior.prototype={initialize:function(){Sys.Extended.UI.AccordionBehavior.callBaseMethod(this,"initialize"),this._headerClickHandler=Function.createDelegate(this,this._onHeaderClick);var e=this.get_ClientState();null!==e&&""!==e&&this._changeSelectedIndex(parseInt(e),!1,!0);var t=this.get_element().childNodes,n={};for(n.value=0;n.value<t.length;n.value++){var s=this._getNextDiv(t,n);if(!s)break;var i=this._getNextDiv(t,n);i&&(this.addPane(s,i),n.value--)}this._requireOpenedPane&&!this.getPane()&&this._panes.length>0&&this._changeSelectedIndex(0,!1,!0),this._initializeLayout()},_getNextDiv:function(e,t){for(var n=null;t.value<e.length&&(n=e[t.value++])&&(!n.tagName||"div"!==n.tagName.toLowerCase()););return n},addPane:function(e,t){var n={};n.animation=null,n.header=e,e._index=this._panes.length,$addHandler(e,"click",this._headerClickHandler);var s=this.get_element(),i=document.createElement("div");return s.insertBefore(i,t),i.appendChild(t),i._original=t,n.content=i,i.style.border="",i.style.margin="",i.style.padding="",Array.add(this._panes,n),this._paneHeaderClassNames.push(n.header.className),this._initializePane(e._index),t.style.display="block",n},_getAnimation:function(e){var t=e.animation;if(!t){var n=null,s=null;this._fadeTransitions?(n=new Sys.Extended.UI.Animation.LengthAnimation(null,null,null,"style","height",0,0,"px"),s=new Sys.Extended.UI.Animation.FadeAnimation(null,null,null,Sys.Extended.UI.Animation.FadeEffect.FadeOut,0,1,(!1)),t=new Sys.Extended.UI.Animation.ParallelAnimation(e.content,this._duration,this._framesPerSecond,[s,n])):t=n=new Sys.Extended.UI.Animation.LengthAnimation(e.content,this._duration,this._framesPerSecond,"style","height",0,0,"px"),e.animation=t,t._length=n,t._fade=s,t._pane=e,t._opening=!0,t._behavior=this,t._ended=Function.createDelegate(e.animation,this._onAnimationFinished),t.add_ended(e.animation._ended),t.initialize()}return t},_onAnimationFinished:function(){this._behavior._endPaneChange(this._pane,this._opening)},_initializeLayout:function(){for(var e=0;e<this._panes.length;e++){var t=this._panes[e].animation;t&&t.get_isPlaying()&&t.stop()}var n=this.get_element();this._initialHeight=n.offsetHeight;var s=n.style;if(this._autoSize===Sys.Extended.UI.AutoSize.None){this._disposeResizeHandler();var i=Sys.Browser.agent==Sys.Browser.InternetExplorer&&Sys.Browser.version>=7;(!i||i&&s.height&&s.height.length>0)&&(s.height="auto"),(!i||i&&s.overflow&&s.overflow.length>0)&&(s.overflow="auto")}else this._addResizeHandler(),s.height=n.offsetHeight+"px",s.overflow="hidden";for(var e=0;e<this._panes.length;e++)this._initializePane(e);this._resizeSelectedPane()},_initializePane:function(e){var t=this.getPane(e);if(t){var n=t.content,s=n._original,i=e===this._selectedIndex;n.style.height=i||this._autoSize===Sys.Extended.UI.AutoSize.Fill?"auto":"0px",n.style.overflow=i?"auto":"hidden",n.style.display=i?"block":"none",s.style.height="auto",s.style.maxHeight="",s.style.overflow=i?"auto":"hidden";var a=i||!this._fadeTransitions?1:0;this._autoSize===Sys.Extended.UI.AutoSize.Fill?($common.getElementOpacity(s)!=a&&$common.setElementOpacity(s,a),1!=$common.getElementOpacity(n)&&$common.setElementOpacity(n,1)):($common.getElementOpacity(n)!=a&&$common.setElementOpacity(n,a),1!=$common.getElementOpacity(s)&&$common.setElementOpacity(s,1)),t.header.className=this._selectedIndex===e?this._headerSelectedCssClass||this._headerCssClass:this._paneHeaderClassNames[e]||this._headerCssClass}},_addResizeHandler:function(){this._resizeHandler||(this._resizeHandler=Function.createDelegate(this,this._resizeSelectedPane),$addHandler(window,"resize",this._resizeHandler))},dispose:function(){this._disposeResizeHandler(),this._disposeAnimations();for(var e=this._panes.length-1;e>=0;e--){var t=this._panes[e];t&&(t.header&&(t.header._index=null,$removeHandler(t.header,"click",this._headerClickHandler),t.header=null),t.content&&(t.content._original=null,t.content=null),this._panes[e]=null,delete this._panes[e])}this._panes=null,this._headerClickHandler=null,Sys.Extended.UI.AccordionBehavior.callBaseMethod(this,"dispose")},_disposeResizeHandler:function(){this._resizeHandler&&($removeHandler(window,"resize",this._resizeHandler),this._resizeHandler=null)},_disposeAnimations:function(){for(var e=0;e<this._panes.length;e++){var t=this._panes[e].animation;t&&(t.get_isPlaying()&&t.stop(),t._ended&&(t.remove_ended(t._ended),t._ended=null),t.dispose(),t._length=null,t._fade=null,t._pane=null,t._opening=null,t._behavior=null,this._panes[e].animation=null)}},_resizeSelectedPane:function(){var e=this.getPane();if(e){this._headersSize=this._getHeadersSize().height;var t=e.content._original;switch(this._autoSize){case Sys.Extended.UI.AutoSize.None:t.style.height="auto",t.style.maxHeight="";break;case Sys.Extended.UI.AutoSize.Limit:var n=this._getRemainingHeight(!1);t.style.height="auto",t.style.maxHeight=n+"px";break;case Sys.Extended.UI.AutoSize.Fill:var n=this._getRemainingHeight(!0);t.style.height=n+"px",t.style.maxHeight=""}}},_onHeaderClick:function(e){for(var t=e.target,n=this.get_element();t&&t.parentNode!==n;)t=t.parentNode;e.stopPropagation(),this._suppressHeaderPostbacks&&e.preventDefault();var s=t._index;s!==this._selectedIndex||this._requireOpenedPane||(s=-1),this._changeSelectedIndex(s,!0)},_changeSelectedIndex:function(e,t,n){var s=this._selectedIndex,i=this.getPane(e),a=this.getPane(s);if(n||i!=a){var d=new Sys.Extended.UI.AccordionSelectedIndexChangeEventArgs(s,e);this.raise_selectedIndexChanging(d),d.get_cancel()||(a&&(a.header.className=this._paneHeaderClassNames[s]||this._headerCssClass),i&&(i.header.className=""==this._headerSelectedCssClass?this._headerCssClass:this._headerSelectedCssClass),this._selectedIndex=e,this.set_ClientState(this._selectedIndex),t&&this._changePanes(s),this.raise_selectedIndexChanged(new Sys.Extended.UI.AccordionSelectedIndexChangeEventArgs(s,e)),this.raisePropertyChanged("SelectedIndex"),this._resizeSelectedPane())}},_changePanes:function(e){if(this.get_isInitialized()){for(var t=null,n=null,s=0;s<this._panes.length;s++){var i=this._panes[s],a=this._getAnimation(i);if(a.get_isPlaying()&&a.stop(),s==this._selectedIndex)a._opening=!0,t=a;else{if(s!=e)continue;a._opening=!1,n=a}this._startPaneChange(i,a._opening),this._fadeTransitions&&a._fade.set_effect(a._opening?Sys.Extended.UI.Animation.FadeEffect.FadeIn:Sys.Extended.UI.Animation.FadeEffect.FadeOut),this._autoSize===Sys.Extended.UI.AutoSize.Fill?(a.set_target(i.content._original),a._length.set_startValue($common.getContentSize(i.content._original).height),a._length.set_endValue(a._opening?this._getRemainingHeight(!0):0)):(a.set_target(i.content),a._length.set_startValue(i.content.offsetHeight),a._length.set_endValue(a._opening?this._getRemainingHeight(!1):0))}n&&n.play(),t&&t.play()}},_startPaneChange:function(e,t){var n=e.content,s=n._original;t?(n.style.display="block",this._autoSize===Sys.Extended.UI.AutoSize.Fill&&this._isIE8InStandardMode&&(s.style.display="block")):(n.style.overflow="hidden",s.style.overflow="hidden",this._autoSize===Sys.Extended.UI.AutoSize.Limit&&(n.style.height=this._getTotalSize(s).height+"px",s.style.maxHeight=""))},_endPaneChange:function(e,t){var n=e.content,s=n._original;if(t){if(this._autoSize===Sys.Extended.UI.AutoSize.Limit){var i=this._getRemainingHeight(!0);s.style.maxHeight=i+"px"}s.style.overflow="auto",n.style.height="auto",n.style.overflow="auto"}else this._isIE8InStandardMode?this._autoSize===Sys.Extended.UI.AutoSize.Fill?s.style.display="none":n.style.height="0px":n.style.display="none"},_getHeadersSize:function(){for(var e={width:0,height:0},t=0;t<this._panes.length;t++){var n=this._getTotalSize(this._panes[t].header);e.width=Math.max(e.width,n.width),e.height+=n.height}return e},_getRemainingHeight:function(e){var t=0,n=this.getPane();if(this._autoSize===Sys.Extended.UI.AutoSize.None)n&&(t=this._getTotalSize(n.content._original).height);else{t=this._headersSize,e&&n&&(t+=this._getGutterSize(n.content._original).height);var s=this.get_element();if(t=Math.max(s.offsetHeight-t,0),n&&this._autoSize===Sys.Extended.UI.AutoSize.Limit){var i=this._getTotalSize(n.content._original).height;i>0&&(t=Math.min(t,i))}}return t},_getTotalSize:function(e){var t=$common.getSize(e),n=$common.getMarginBox(e);return t.width+=n.horizontal,t.height+=n.vertical,t},_getGutterSize:function(e){var t={width:0,height:0};try{var n=$common.getPaddingBox(e);t.width+=n.horizontal,t.height+=n.vertical}catch(e){}try{var n=$common.getBorderBox(e);t.width+=n.horizontal,t.height+=n.vertical}catch(e){}var n=$common.getMarginBox(e);return t.width+=n.horizontal,t.height+=n.vertical,t},add_selectedIndexChanging:function(e){this.get_events().addHandler("selectedIndexChanging",e)},remove_selectedIndexChanging:function(e){this.get_events().removeHandler("selectedIndexChanging",e)},raiseSelectedIndexChanging:function(e){Sys.Extended.Deprecated("raiseSelectedIndexChanging(eventArgs)","raise_selectedIndexChanging(eventArgs)"),this.raise_selectedIndexChanging(e)},raise_selectedIndexChanging:function(e){var t=this.get_events().getHandler("selectedIndexChanging");t&&t(this,e)},add_selectedIndexChanged:function(e){this.get_events().addHandler("selectedIndexChanged",e)},remove_selectedIndexChanged:function(e){this.get_events().removeHandler("selectedIndexChanged",e)},raiseSelectedIndexChanged:function(e){Sys.Extended.Deprecated("raiseSelectedIndexChanged(eventArgs)","raise_selectedIndexChanged(eventArgs)"),this.raise_selectedIndexChanged(e)},raise_selectedIndexChanged:function(e){var t=this.get_events().getHandler("selectedIndexChanged");t&&t(this,e)},getPane:function(e){return void 0!==e&&null!==e||(e=this._selectedIndex),this._panes&&e>=0&&e<this._panes.length?this._panes[e]:null},get_Pane:function(e){return Sys.Extended.Deprecated("get_Pane(index)","getPane(index)"),this.getPane(e)},getCount:function(){return this._panes?this._panes.length:0},get_Count:function(){return Sys.Extended.Deprecated("get_Count()","getCount()"),this.getCount()},get_TransitionDuration:function(){return Sys.Extended.Deprecated("get_TransitionDuration()","get_transitionDuration()"),this.get_transitionDuration()},get_transitionDuration:function(){return 1e3*this._duration},set_TransitionDuration:function(e){Sys.Extended.Deprecated("set_TransitionDuration(value)","set_transitionDuration(value)"),this.set_transitionDuration(e)},set_transitionDuration:function(e){if(this._duration!=e/1e3){this._duration=e/1e3;for(var t=0;t<this._panes.length;t++){var n=this._panes[t].animation;n&&n.set_duration(this._duration)}this.raisePropertyChanged("TransitionDuration")}},get_FramesPerSecond:function(){return Sys.Extended.Deprecated("get_FramesPerSecond()","get_framesPerSecond()"),this.get_framesPerSecond()},get_framesPerSecond:function(){return this._framesPerSecond},set_FramesPerSecond:function(e){Sys.Extended.Deprecated("set_FramesPerSecond(value)","set_framesPerSecond(value)"),this.set_framesPerSecond(e)},set_framesPerSecond:function(e){if(this._framesPerSecond!=e){this._framesPerSecond=e;for(var t=0;t<this._panes.length;t++){var n=this._panes[t].animation;n&&n.set_fps(this._framesPerSecond)}this.raisePropertyChanged("FramesPerSecond")}},get_FadeTransitions:function(){return Sys.Extended.Deprecated("get_FadeTransitions()","get_fadeTransitions()"),this.get_fadeTransitions()},get_fadeTransitions:function(){return this._fadeTransitions},set_FadeTransitions:function(e){return Sys.Extended.Deprecated("set_FadeTransitions(value)","set_fadeTransitions(value)"),this.set_fadeTransitions(e)},set_fadeTransitions:function(e){if(this._fadeTransitions!=e){if(this._fadeTransitions=e,this._disposeAnimations(),!this._fadeTransitions)for(var t=0;t<this._panes.length;t++)1!=$common.getElementOpacity(this._panes[t].content)&&$common.setElementOpacity(this._panes[t].content,1),1!=$common.getElementOpacity(this._panes[t].content._original)&&$common.setElementOpacity(this._panes[t].content._original,1);this.raisePropertyChanged("FadeTransitions")}},get_HeaderCssClass:function(){return Sys.Extended.Deprecated("get_HeaderCssClass()","get_headerCssClass()"),this.get_headerCssClass()},get_headerCssClass:function(){return this._headerCssClass},set_HeaderCssClass:function(e){Sys.Extended.Deprecated("set_HeaderCssClass(value)","set_headerCssClass(value)"),this.set_headerCssClass()},set_headerCssClass:function(e){this._headerCssClass=e,this.raisePropertyChanged("HeaderCssClass")},get_HeaderSelectedCssClass:function(){return Sys.Extended.Deprecated("get_headerSelectedCssClass()","get_headerSelectedCssClass()"),this.get_selectedIndex()},get_headerSelectedCssClass:function(){return this._headerSelectedCssClass},set_HeaderSelectedCssClass:function(e){Sys.Extended.Deprecated("set_HeaderSelectedCssClass(value)","set_headerSelectedCssClass(value)"),this.set_headerSelectedCssClass(e)},set_headerSelectedCssClass:function(e){this._headerSelectedCssClass=e,this.raisePropertyChanged("HeaderSelectedCssClass")},get_AutoSize:function(){return Sys.Extended.Deprecated("get_AutoSize()","get_autoSize()"),get_autoSize()},get_autoSize:function(){return this._autoSize},set_AutoSize:function(e){Sys.Extended.Deprecated("set_AutoSize(value)","set_autoSize(value)"),this.set_autoSize(e)},set_autoSize:function(e){Sys.Browser.agent===Sys.Browser.InternetExplorer&&e===Sys.Extended.UI.AutoSize.Limit&&(e=Sys.Extended.UI.AutoSize.Fill),this._autoSize!=e&&(this._autoSize=e,this._initializeLayout(),this.raisePropertyChanged("AutoSize"))},get_SelectedIndex:function(){return Sys.Extended.Deprecated("get_SelectedIndex()","get_selectedIndex()"),this.get_selectedIndex()},get_selectedIndex:function(){return this._selectedIndex},set_SelectedIndex:function(e){Sys.Extended.Deprecated("set_SelectedIndex(value)","set_selectedIndex(value)"),this.set_selectedIndex(e)},set_selectedIndex:function(e){this._changeSelectedIndex(e,!0)},get_requireOpenedPane:function(){return this._requireOpenedPane},set_requireOpenedPane:function(e){this._requireOpenedPane!=e&&(this._requireOpenedPane=e,this.raisePropertyChanged("requireOpenedPane"))},get_suppressHeaderPostbacks:function(){return this._suppressHeaderPostbacks},set_suppressHeaderPostbacks:function(e){this._suppressHeaderPostbacks!=e&&(this._suppressHeaderPostbacks=e,this.raisePropertyChanged("suppressHeaderPostbacks"))}},Sys.Extended.UI.AccordionBehavior.registerClass("Sys.Extended.UI.AccordionBehavior",Sys.Extended.UI.BehaviorBase);