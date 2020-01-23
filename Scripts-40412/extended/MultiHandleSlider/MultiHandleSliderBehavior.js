// (c) 2010 CodePlex Foundation
(function(){var b="ExtendedMultiHandleSlider";function a(){var q="dragEnd",p="drag",o="dragStart",n="valueChanged",m="load",v="keypress",u="onmousewheel",t="DOMMouseScroll",s="mouseout",i="DIV",l="handle_horizontal",k="handle_vertical",r="ajax__multi_slider_default",j="selectstart",g="change",e="px",f="none",h="INPUT",d="",c=true,b=false,a=null;Type.registerNamespace("Sys.Extended.UI");Sys.Extended.UI._MultiHandleSliderDragDropInternal=function(){Sys.Extended.UI._MultiHandleSliderDragDropInternal.initializeBase(this);this._instance=a};Sys.Extended.UI._MultiHandleSliderDragDropInternal.prototype={_getInstance:function(){var a=this;a._instance=new Sys.Extended.UI.GenericDragDropManager;a._instance.initialize();a._instance.add_dragStart(Function.createDelegate(a,a._raiseDragStart));a._instance.add_dragStop(Function.createDelegate(a,a._raiseDragStop));return a._instance}};Sys.Extended.UI._MultiHandleSliderDragDropInternal.registerClass("Sys.Extended.UI._MultiHandleSliderDragDropInternal",Sys.Extended.UI._DragDropManager);Sys.Extended.UI.DragDrop=new Sys.Extended.UI._MultiHandleSliderDragDropInternal;Sys.Extended.UI.MultiHandleInnerRailStyle=function(){};Sys.Extended.UI.MultiHandleInnerRailStyle.prototype={AsIs:0,SlidingDoors:1};Sys.Extended.UI.MultiHandleInnerRailStyle.registerEnum("Sys.Extended.UI.MultiHandleInnerRailStyle",b);Sys.Extended.UI.SliderOrientation=function(){};Sys.Extended.UI.SliderOrientation.prototype={Horizontal:0,Vertical:1};Sys.Extended.UI.SliderOrientation.registerEnum("Sys.Extended.UI.SliderOrientation",b);Sys.Extended.UI.MultiHandleSliderBehavior=function(f){var e=this;Sys.Extended.UI.MultiHandleSliderBehavior.initializeBase(e,[f]);e._isServerControl=b;e._minimum=a;e._maximum=a;e._orientation=Sys.Extended.UI.SliderOrientation.Horizontal;e._cssClass=a;e._multiHandleSliderTargets=a;e._length=150;e._steps=0;e._enableHandleAnimation=b;e._showInnerRail=b;e._showHoverStyle=b;e._showDragStyle=b;e._raiseChangeOnlyOnMouseUp=c;e._innerRailStyle=Sys.Extended.UI.MultiHandleInnerRailStyle.AsIs;e._enableInnerRangeDrag=b;e._enableRailClick=c;e._isReadOnly=b;e._increment=1;e._enableKeyboard=c;e._enableMouseWheel=c;e._tooltipText=d;e._boundControlID=a;e._handleCssClass=a;e._handleImageUrl=a;e._handleImage=a;e._railCssClass=a;e._decimals=0;e._textBox=a;e._wrapper=a;e._outer=a;e._inner=a;e._handleData=a;e._handleAnimationDuration=.02;e._handles=0;e._innerDragFlag=b;e._isVertical=b;e._selectStartHandler=a;e._mouseUpHandler=a;e._mouseOutHandler=a;e._keyDownHandler=a;e._mouseWheelHandler=a;e._mouseOverHandler=a;e._animationPending=b;e._selectStartPending=b;e._initialized=b;e._handleUnderDrag=a;e._innerDrag=b;e._blockInnerClick=b};Sys.Extended.UI.MultiHandleSliderBehavior.prototype={initialize:function(){var a=this;Sys.Extended.UI.MultiHandleSliderBehavior.callBaseMethod(a,"initialize");if(a._boundControlID&&!a._multiHandleSliderTargets)a._multiHandleSliderTargets=[{ControlID:a._boundControlID,HandleCssClass:a._handleCssClass,HandleImageUrl:a._handleImageUrl,Decimals:a._decimals}];a._handles=a._multiHandleSliderTargets?a._multiHandleSliderTargets.length:0;if(a._handles===0){var b=document.createElement(h);b.id="boundless";b.style.display=f;b.value=a.get_minimum();document.forms[0].appendChild(b);a._multiHandleSliderTargets=[{ControlID:b.id,HandleCssClass:a._handleCssClass,HandleImageUrl:a._handleImageUrl,Decimals:a._decimals}];a._boundControlID=b.id;a._handles=1}a._isVertical=a._orientation===Sys.Extended.UI.SliderOrientation.Vertical;a._resolveNamingContainer();a._createWrapper();a._createOuterRail();a._createHandles();a._createInnerRail();a._setRailStyles();if(a._length)if(!a._cssClass&&a._innerRailStyle!==Sys.Extended.UI.MultiHandleInnerRailStyle.SlidingDoors)if(a._isVertical)a._outer.style.height=a._length+e;else a._outer.style.width=a._length+e;a._build();a._enforceElementPositioning();a._initializeSlider()},dispose:function(){var a=this;a._disposeHandlers();a._disposeMultiHandleSliderTargets();a._enableHandleAnimation&&a._handleAnimation&&a._handleAnimation.dispose();Sys.Extended.UI.MultiHandleSliderBehavior.callBaseMethod(a,"dispose")},get_SliderInitialized:function(){return this._initialized},getValue:function(b){var a=$get(this._multiHandleSliderTargets[b].ControlID);return a.value},setValue:function(c,d){var a=this,b=$get(a._multiHandleSliderTargets[c].ControlID);if(b){a.beginUpdate();a._setMultiHandleSliderTargetValue(b,a._getNearestStepValue(d));a.endUpdate()}},get_values:function(){for(var b=[this._handles],a=0;a<this._handles;a++){var c=this._multiHandleSliderTargets[a];b[a]=c.value}return b.join(",")},_build:function(){var a=this;a._textBox=a.get_element();a._textBox.parentNode.insertBefore(a._wrapper,a._textBox);a._wrapper.appendChild(a._outer);a._inner&&a._showInnerRail&&a._outer.appendChild(a._inner);a._textBox.style.display=f},_calculateInnerRailOffset:function(c){var a=this,d=a._isVertical?a._inner.style.top:a._inner.style.left,b=a._isVertical?c.offsetY:c.offsetX;b+=parseInt(d,10);return b},_calculateClick:function(a){var b=this,j=b._getOuterBounds(),d=b._handleData[0],i=b._getBoundsInternal(d);d=b._calculateClosestHandle(a);var e=i.width/2,f=j.width-e;a=a<e?e:a>f?f:a;var h=$get(d.multiHandleSliderTargetID);b._calculateMultiHandleSliderTargetValue(h,a,c);$common.tryFireEvent(b.get_element(),g)},_calculateClosestHandle:function(h){var a=this;for(var c=a._handleData[0],d=[a._handles],k=a._getOuterBounds(),b=0;b<a._handles;b++){var e=a._handleData[b],n=a._getBoundsInternal(e),o=a._isVertical?e.offsetTop:n.x-k.x;d[b]=Math.abs(o-h)}var i=d[0];for(b=0;b<a._handles;b++){var l=d[b];if(l<i){e=a._handleData[b];i=l;c=e}}if(a._innerDrag){var j=Array.indexOf(a._handleData,c),g=Sys.UI.DomElement.getLocation(c),m=a._isVertical?g.y:g.x-k.x;if(m>=h+d[j]){var f=a._handleData[j-1];if(f)c=f}}return c},_calculateMultiHandleSliderTargetValue:function(h,x,E){var a=this,e,l,g=a._minimum,f=a._maximum;if(a._handleUnderDrag&&!h){j=a._handleUnderDrag;h=$get(a._handleUnderDrag.multiHandleSliderTargetID);if(a._innerDrag){var z=Array.indexOf(a._handleData,j);e=a._handleData[z+1];if(!e)e=a._handleData[z-1];l=$get(e.multiHandleSliderTargetID)}}var j=h.Handle,d=h.value;if(d&&!E){if(typeof d!=="number")try{d=parseFloat(d)}catch(J){d=Number.NaN}if(isNaN(d))d=a._minimum;val=Math.max(Math.min(d,f),g)}else{var m=a._getBoundsInternal(j),p=a._getOuterBounds(),q=x?x-m.width/2:m.x-p.x,G=p.width-m.width,F=q/G;val=Math.max(Math.min(d,f),g);val=q===0?g:q===p.width-m.width?f:g+F*(f-g)}if(a._steps>0)val=a._getNearestStepValue(val);val=Math.max(Math.min(val,f),g);for(var u=[],w=[],o=0,r=0,n,A=c,k=0;k<a._handles;k++){var I=a._multiHandleSliderTargets[k];if(!I.ControlID.match(h.id))if(A){u[o]=a._multiHandleSliderTargets[k];o++}else{w[r]=a._multiHandleSliderTargets[k];r++}else A=b}if(o>0){var C=parseFloat($get(u[o-1].ControlID).value);val=Math.max(val,C);n=val===C}if(r>0){var B=parseFloat($get(w[0].ControlID).value);val=Math.min(val,B);n=val===B}if(e){var H=val-parseFloat(d),v=parseFloat(l.value),i=v+H,y=Array.indexOf(a._handleData,e)+1;if(y<a._multiHandleSliderTargets.length)var s=a._multiHandleSliderTargets[y].ControlID;if(s)var t=$get(s);if(t)var D=t.value;if(i>(D||f)){i=v;val=d;n=c}}if(!n&&(Math.max(val,f)===f&&Math.min(val,g)===g)){a.beginUpdate();val=Math.max(Math.min(val,f),g);a._setMultiHandleSliderTargetValue(h,val);e&&a._setMultiHandleSliderTargetValue(l,i);a.endUpdate()}else{a.beginUpdate();if(a._handles===1)a._setMultiHandleSliderTargetValue(h,val);else{h.value=val;j.Value=val;a._setHandlePosition(j,c)}if(e){l.value=i;e.Value=i;a._setHandlePosition(e,c)}a.endUpdate()}return val},_cancelDrag:function(){if(Sys.Extended.UI.MultiHandleSliderBehavior.DropPending===this){Sys.Extended.UI.MultiHandleSliderBehavior.DropPending=a;this._selectStartPending&&$removeHandler(document,j,this._selectStartHandler)}},_createHandles:function(){var a=this;for(var c=0;c<a._handles;c++){var s=a.get_id()+"_handle_"+c,i=a._isVertical,f=d,g=d,h=d;if(a._handles===1&&a._handleImageUrl)var o="<img id='"+a.get_id()+"_handleImage' src='"+a._handleImageUrl+"' alt='' />";var q="<a id='"+s+"' ",v=o?o:d,t="><div>"+v+"</div></a>";a._outer.innerHTML+=q+t}a._handleData=[a._handles];for(c=0;c<a._handles;c++){var u=a._cssClass?a._cssClass:r,e=a._multiHandleSliderTargets[c].HandleCssClass;if(e||a._cssClass){f=e?e+" ":a._cssClass+" ";g=f;h=f;var n=e,m=e;f=!e?f+a._isVertical?k:l:f+e;g=!m?g+a._isVertical?"handle_vertical_hover":"handle_horizontal_hover":g+m;h=!n?h+a._isVertical?"handle_vertical_down":"handle_horizontal_down":h+n}a._handleCallbacks={mouseover:Function.createCallback(a._onShowHover,{vertical:i,custom:g}),mouseout:Function.createCallback(a._onHideHover,{vertical:i,custom:f}),mousedown:Function.createCallback(a._onShowDrag,{vertical:i,custom:h}),mouseup:Function.createCallback(a._onHideDrag,{vertical:i,custom:f})};a._handleData[c]=a._outer.childNodes[c];a._handleData[c].style.overflow="hidden";$addHandlers(a._handleData[c],a._handleCallbacks);e=a._multiHandleSliderTargets[c].HandleCssClass;if(e){Sys.UI.DomElement.addCssClass(a._handleData[c],u);Sys.UI.DomElement.addCssClass(a._handleData[c],e)}else a._handleData[c].className=a._isVertical?k:l;if(a._multiHandleSliderTargets){var p=a._multiHandleSliderTargets[c].ControlID;a._handleData[c].multiHandleSliderTargetID=p}a._handleData[c].style.left="0px";a._handleData[c].style.top="0px";if(a._steps<1){if(a._enableHandleAnimation){var j=new Sys.Extended.UI.Animation.LengthAnimation(a._handleData[c],a._handleAnimationDuration,100,"style");j.add_ended(Function.createDelegate(a,a._onAnimationEnded));j.add_step(Function.createDelegate(a,a._onAnimationStep));a._handleData[c].Animation=j}}else a._enableHandleAnimation=b}},_createInnerRail:function(){var a=this;if(a._handles>1&&a._showInnerRail){a._inner=document.createElement(i);a._inner.id=a.get_id()+"_inner";a._inner.style.outline=f;a._inner.tabIndex=-1}},_createOuterRail:function(){var a=this;a._outer=document.createElement(i);a._outer.id=a.get_id()+"_outer";a._outer.style.outline=f;a._outer.tabIndex=-1},_createWrapper:function(){this._wrapper=document.createElement(i);this._wrapper.style.position="relative";this._wrapper.style.outline=f},_disposeHandlers:function(){var c=this;if(!c._isReadOnly){$removeHandler(document,"mouseup",c._mouseUpHandler);$removeHandler(document,s,c._mouseOutHandler);if(c._outer){if(c._outer.addEventListener)c._outer.removeEventListener(t,c._mouseWheelHandler,b);else c._outer.detachEvent(u,c._mouseWheelHandler);$common.removeHandlers(c._outer,c._outerDelegates)}for(var d=0;d<c._handles;d++){c._handleDelegates&&$common.removeHandlers(c._handleData[d],c._handleDelegates);c._handleCallbacks&&$clearHandlers(c._handleData[d])}c._handleDelegates=a;c._handleCallbacks=a;c._inner&&c._showInnerRail&&c._innerDelegates&&$common.removeHandlers(c._inner,c._innerDelegates);c._selectStartHandler=a;c._mouseUpHandler=a;c._mouseOutHandler=a;c._mouseWheelHandler=a;c._mouseOverHandler=a;c._keyDownHandler=a}},_disposeMultiHandleSliderTargets:function(){if(this._multiHandleSliderTargets)for(var c=0;c<this._handles;c++){var b=this._multiHandleSliderTargets[c],d=b&&b.nodeName===h;if(d){$removeHandler(b,g,b.ChangeHandler);$removeHandler(b,v,b.KeyPressHandler);b.ChangeHandler=a;b.KeyPressHandler=a}}},_ensureBinding:function(a){if(a){var b=a.value;if(b>=this._minimum||b<=this._maximum){var c=a&&a.nodeName===h;if(c)a.value=b;else if(a)a.innerHTML=b}}},_enforceElementPositioning:function(){var b=this,a={position:b.get_element().style.position,top:b.get_element().style.top,right:b.get_element().style.right,bottom:b.get_element().style.bottom,left:b.get_element().style.left};if(a.position!==d)b._wrapper.style.position=a.position;if(a.top!==d)b._wrapper.style.top=a.top;if(a.right!==d)b._wrapper.style.right=a.right;if(a.bottom!==d)b._wrapper.style.bottom=a.bottom;if(a.left!==d)b._wrapper.style.left=a.left},_getNearestStepValue:function(b){var a=this;if(a._steps===0)return b;var c=a._maximum-a._minimum;if(c===0)return b;if(a._steps-1!==0)var d=c/(a._steps-1);else return b;return Math.round(b/d)*d},_getStepValues:function(){var a=this,c=[a._steps],e=a._maximum-a._minimum,d=e/(a._steps-1);c[0]=a._minimum;for(var b=1;b<a._steps;b++)c[b]=a._minimum+d*b;return c},_handleSlide:function(b){var a=this,e=b?0:a._handles-1,f=b?1:0,g=b?a._handles:a._handles-1,c=a._handleData[e].multiHandleSliderTargetID;if(a._slideMultiHandleSliderTarget(c,b))for(var d=f;d<g;d++){c=a._handleData[d].multiHandleSliderTargetID;a._slideMultiHandleSliderTarget(c,b)}a._initializeInnerRail()},_initializeDragHandle:function(b){var a=b.DragHandle=document.createElement(i);a.style.position="absolute";a.style.width="1px";a.style.height="1px";a.style.overflow="hidden";a.style.background=f;document.forms[0].appendChild(b.DragHandle)},_initializeHandlers:function(){var a=this;if(!a._isReadOnly){a._selectStartHandler=Function.createDelegate(a,a._onSelectStart);a._mouseUpHandler=Function.createDelegate(a,a._onMouseUp);a._mouseOutHandler=Function.createDelegate(a,a._onMouseOut);a._mouseWheelHandler=Function.createDelegate(a,a._onMouseWheel);a._mouseOverHandler=Function.createDelegate(a,a._onMouseOver);a._keyDownHandler=Function.createDelegate(a,a._onKeyDown);$addHandler(document,"mouseup",a._mouseUpHandler);$addHandler(document,s,a._mouseOutHandler);a._handleDelegates={mousedown:Function.createDelegate(a,a._onMouseDown),dragstart:Function.createDelegate(a,a._IEDragDropHandler),drag:Function.createDelegate(a,a._IEDragDropHandler),dragEnd:Function.createDelegate(a,a._IEDragDropHandler)};for(var c=0;c<a._handles;c++)$addHandlers(a._handleData[c],a._handleDelegates);if(a._outer){if(a._enableMouseWheel)if(a._outer.addEventListener)a._outer.addEventListener(t,a._mouseWheelHandler,b);else a._outer.attachEvent(u,a._mouseWheelHandler);a._outerDelegates={click:Function.createDelegate(a,a._onOuterRailClick),mouseover:Function.createDelegate(a,a._mouseOverHandler),keydown:Function.createDelegate(a,a._keyDownHandler)};$addHandlers(a._outer,a._outerDelegates)}if(a._inner&&a._showInnerRail){a._innerDelegates={click:Function.createDelegate(a,a._onInnerRailClick),mousedown:Function.createDelegate(a,a._onMouseDownInner),mouseup:Function.createDelegate(a,a._onMouseUpInner),mouseout:Function.createDelegate(a,a._onMouseOutInner),mousemove:Function.createDelegate(a,a._onMouseMoveInner),dragStart:Function.createDelegate(a,a._IEDragDropHandler),drag:Function.createDelegate(a,a._IEDragDropHandler),dragEnd:Function.createDelegate(a,a._IEDragDropHandler)};$addHandlers(a._inner,a._innerDelegates)}}},_initializeHandles:function(){var a=this,f=a.get_ClientState();if(f)var e=f.split(",",a._handles);for(var d=0;d<a._handles;d++){var b=a._handleData[d],g=a._multiHandleSliderTargets[d].Decimals;if(e)b.Value=parseFloat(e[d]);a._initializeMultiHandleSliderTarget(b.multiHandleSliderTargetID,g,b);a._initializeHandleValue(b);a._setHandlePosition(b,c);a._initializeDragHandle(b)}},_initializeHandleValue:function(b){if(!b.Value){try{var a=$get(b.multiHandleSliderTargetID),d=a&&a.nodeName===h,c=parseFloat(d?a.value:a.innerHTML)}catch(e){c=Number.NaN}if(isNaN(c)){b.Value=this._minimum;if(d)a.value=b.Value;else a.innerHTML=b.Value}else b.Value=c}},_initializeInnerRail:function(){var b=this;if(b._inner&&b._showInnerRail){var i=0,j=b._handles-1,g=b._handleData[i],f=b._handles>1?b._handleData[j]:a;if(f){var h=parseInt(b._getBoundsInternal(g).width,10),c=parseInt(b._isVertical?g.style.top:g.style.left,10),d=parseInt(b._isVertical?f.style.top:f.style.left,10),k=parseInt(b._multiHandleSliderTargets[i].Offset,10),l=parseInt(b._multiHandleSliderTargets[j].Offset,10);c+=k;d+=l;if(b._isVertical){b._inner.style.top=c+e;b._inner.style.height=d+h-c+e}else{b._inner.style.left=c+e;b._inner.style.width=d+h-c+e}if(b._innerRailStyle===Sys.Extended.UI.MultiHandleInnerRailStyle.SlidingDoors)b._inner.style.backgroundPosition=b._isVertical?"0 -"+c+e:"-"+c+"px 0"}}},_initializeMultiHandleSliderTarget:function(d,e,c){var b=this;if(d){var a=$get(d);if(c.Value)a.value=c.Value;a.Handle=c;a.Decimals=e;a.OldValue=a.value;a.onchange="setValue(this, "+a.value+")";if(!a.Decimals)a.Decimals=0;var f=a&&a.nodeName===h;if(f){a.KeyPressHandler=Function.createDelegate(b,b._onMultiHandleSliderTargetKeyPressed);a.ChangeHandler=Function.createDelegate(b,b._onMultiHandleSliderTargetChange);$addHandler(a,v,a.KeyPressHandler);$addHandler(a,g,a.ChangeHandler)}}},_initializeSlider:function(){var a=this;Sys.Extended.UI.DragDrop.registerDropTarget(a);a._initializeHandles();a._initializeHandlers();a._initializeInnerRail();a._initialized=c;a._raiseEvent(m)},_resetDragHandle:function(b){var a=$common.getBounds(b);$common.setLocation(b.DragHandle,{x:a.x,y:a.y})},_resolveNamingContainer:function(){var a=this;if(a._isServerControl&&a._multiHandleSliderTargets&&!a._boundControlID)for(var c=a._clientStateFieldID.lastIndexOf(a._id),d=a._clientStateFieldID.substring(0,c),b=0;b<a._handles;b++)a._multiHandleSliderTargets[b].ControlID=d+a._multiHandleSliderTargets[b].ControlID},_saveState:function(){var a=this;for(var c=[a._handles],b=0;b<a._handles;b++)c[b]=$get(a._multiHandleSliderTargets[b].ControlID).value;a.set_ClientState(c.join(","))},_setHandlePosition:function(d,m){var c="width",a=this,j=a._minimum,l=a._maximum,i=d.Value,o=a._enableHandleAnimation&&a._animationPending&&m,f=a._getBoundsInternal(d),g=a._getOuterBounds();if(f.width<=0&&g.width<=0){f.width=parseInt($common.getCurrentStyle(d,c),10);g.width=parseInt($common.getCurrentStyle(a._outer,c),10);if(f.width<=0||g.width<=0)throw Error.argument(c,Sys.Extended.UI.Resources.MultiHandleSlider_CssHeightWidthRequired);}var p=l-j,n=(i-j)/p,h=Math.round(n*(g.width-f.width)),k=i===j?0:i===l?g.width-f.width:h;if(o){d.Animation.set_startValue(f.x-g.x);d.Animation.set_endValue(k);d.Animation.set_propertyKey(a._isVertical?"top":"left");d.Animation.play();a._animationPending=b}else{h=k+e;if(a._isVertical)d.style.top=h;else d.style.left=h}},_setRailStyles:function(){var c="inner_rail_horizontal",b="inner_rail_vertical",a=this;if(!a._inner&&a._railCssClass){a._outer.className=a._railCssClass;return}var d=a._cssClass?a._cssClass:r;Sys.UI.DomElement.addCssClass(a.get_element(),d);Sys.UI.DomElement.addCssClass(a._outer,d);Sys.UI.DomElement.addCssClass(a._wrapper,d);if(a._inner){Sys.UI.DomElement.addCssClass(a._inner,d);var e=a._isVertical?"outer_rail_vertical":"outer_rail_horizontal",f=a._isVertical?b:c;Sys.UI.DomElement.addCssClass(a._outer,e);Sys.UI.DomElement.addCssClass(a._inner,f)}else{e=a._isVertical?b:c;Sys.UI.DomElement.addCssClass(a._outer,e)}},_setMultiHandleSliderTargetValue:function(b,h){var a=this,e=b.OldValue,d=h;if(e===d&&a._isReadOnly)b.value=e;else{if(!a.get_isUpdating())d=a._calculateMultiHandleSliderTargetValue(b);b.value=d.toFixed(b.Decimals);a._ensureBinding(b);if(!Number.isInstanceOfType(b.value))try{b.value=parseFloat(b.value)}catch(i){b.value=Number.NaN}if(a._tooltipText){var f=b.Handle;f.alt=f.title=String.format(a._tooltipText,b.value)}if(a._initialized){b.Handle.Value=d;a._setHandlePosition(b.Handle,c);if(a._handles===1)a.get_element().value=d;if(b.value!==e){b.OldValue=b.value;a._initializeInnerRail();if(a._innerDrag)a._blockInnerClick=c;a._raiseEvent(n);if(a.get_isUpdating())!a._raiseChangeOnlyOnMouseUp&&$common.tryFireEvent(a.get_element(),g)}}}a._saveState()},_setValueFromMultiHandleSliderTarget:function(b){var a=this;a.beginUpdate();if(b)if(!a._isReadOnly){a._handles===1&&a._steps>0&&a._setMultiHandleSliderTargetValue(b,b.value);a._calculateMultiHandleSliderTargetValue(b)}else a._setMultiHandleSliderTargetValue(b,b.OldValue);a.endUpdate()},_slideMultiHandleSliderTarget:function(i,g){var b=this,d=$get(i),j=d.value,c,a;if(b._steps>0){var e=b._getStepValues(),f=b._getNearestStepValue(j);c=f;if(g){for(a=b._steps-1;a>-1;a--)if(e[a]<f){c=e[a];break}}else for(a=0;a<b._steps;a++)if(e[a]>f){c=e[a];break}}else{var h=parseFloat(d.value);c=g?h-parseFloat(b._increment):h+parseFloat(b._increment)}d.value=c;b._setValueFromMultiHandleSliderTarget(d);return d.value==c},_startDragDrop:function(b){this._resetDragHandle(b);this._handleUnderDrag=b;Sys.Extended.UI.DragDrop.startDragDrop(this,b.DragHandle,a)},_onAnimationEnded:function(){this._initializeInnerRail()},_onAnimationStep:function(){this._initializeInnerRail()},_onHideDrag:function(b,a){this.className=a.custom&&a.custom.length>0?a.custom:a.vertical?k:l},_onHideHover:function(b,a){this.className=a.custom&&a.custom.length>0?a.custom:a.vertical?"ajax__multi_slider_default handle_vertical":"ajax__multi_slider_default handle_horizontal"},_onInnerRailClick:function(d){var a=this;if(a._enableRailClick){var e=d.target;if(e===a._inner&&!a._blockInnerClick){a._animationPending=c;a._onInnerRailClicked(d)}else a._blockInnerClick=b}},_onInnerRailClicked:function(b){var a=this._calculateInnerRailOffset(b);this._calculateClick(a)},_onKeyDown:function(e){if(this._enableKeyboard){var d=new Sys.UI.DomEvent(e),a=b;switch(d.keyCode||d.rawEvent.keyCode){case Sys.UI.Key.up:case Sys.UI.Key.left:if(!a){this._handleSlide(c);d.preventDefault();a=c}return b;case Sys.UI.Key.down:case Sys.UI.Key.right:if(!a){this._handleSlide(b);d.preventDefault();a=c}return b;default:return b}}},_onMouseOver:function(){this._outer.focus()},_onMouseWheel:function(c){var a=0;if(c.wheelDelta){a=c.wheelDelta/120;if(Sys.Browser.agent===Sys.Browser.Opera)a=-a}else if(c.detail)a=-c.detail/3;a&&this._handleSlide(a<=0);c.preventDefault&&c.preventDefault();return b},_onMouseUp:function(a){window._event=a;a.preventDefault();this._cancelDrag()},_onMouseOut:function(a){window._event=a;a.preventDefault();this._outer.blur();this._handleUnderDrag&&this._cancelDrag()},_onMouseOutInner:function(a){window._event=a;a.preventDefault();this._inner.blur();this._innerDrag&&this._cancelDrag()},_onMouseDown:function(b){var a=this;window._event=b;b.preventDefault();if(!Sys.Extended.UI.MultiHandleSliderBehavior.DropPending){Sys.Extended.UI.MultiHandleSliderBehavior.DropPending=a;$addHandler(document,j,a._selectStartHandler);a._selectStartPending=c;var d=b.target;a._startDragDrop(d)}},_onMouseDownInner:function(a){window._event=a;a.preventDefault();if(this._enableInnerRangeDrag)if(!this._innerDragFlag)this._innerDragFlag=c},_onMouseUpInner:function(){if(this._enableInnerRangeDrag)this._innerDragFlag=b},_onMouseMoveInner:function(d){var a=this;window._event=d;d.preventDefault();if(a._enableInnerRangeDrag)if(!a._innerDrag&&a._innerDragFlag){a._innerDragFlag=b;if(!Sys.Extended.UI.MultiHandleSliderBehavior.DropPending){Sys.Extended.UI.MultiHandleSliderBehavior.DropPending=a;$addHandler(document,j,a._selectStartHandler);a._selectStartPending=c;a._innerDrag=c;var f=a._calculateInnerRailOffset(d),e=a._calculateClosestHandle(f);a._startDragDrop(e)}}},_onMultiHandleSliderTargetChange:function(a){this._animationPending=c;var b=a.target;this._setValueFromMultiHandleSliderTarget(b);this._initializeInnerRail();a.preventDefault()},_onMultiHandleSliderTargetKeyPressed:function(d){var a=new Sys.UI.DomEvent(d);if(a.charCode===13){this._animationPending=c;var b=a.target;this._setValueFromMultiHandleSliderTarget(b);this._initializeInnerRail();a.preventDefault()}},_onOuterRailClick:function(b){var a=this;if(a._enableRailClick){var d=b.target;if(d===a._outer){a._animationPending=c;a._onOuterRailClicked(b)}}},_onOuterRailClicked:function(a){var b=this._isVertical?a.offsetY:a.offsetX;this._calculateClick(b)},_onShowDrag:function(b,a){this.className=a.custom&&a.custom.length>0?a.custom:a.vertical?"ajax__multi_slider_default handle_vertical_down":"ajax__multi_slider_default handle_horizontal_down"},_onShowHover:function(b,a){this.className=a.custom&&a.custom.length>0?a.custom:a.vertical?"ajax__multi_slider_default handle_vertical_hover":"ajax__multi_slider_default handle_horizontal_hover"},get_dragDataType:function(){return"HTML"},getDragData:function(){return this._handleUnderDrag},get_dragMode:function(){return Sys.Extended.UI.DragMode.Move},onDragStart:function(){this._resetDragHandle(this._handleUnderDrag);this._raiseEvent(o)},onDrag:function(){var d=this,f=d._getBoundsInternal(d._handleUnderDrag.DragHandle),h=d._getBoundsInternal(d._handleUnderDrag),g=d._getOuterBounds(),e;if(d._isVertical)e={y:f.x-g.x,x:0};else e={x:f.x-g.x,y:0};$common.setLocation(d._handleUnderDrag,e);d._calculateMultiHandleSliderTargetValue(a,a,c);d._steps>1&&d._setHandlePosition(d._handleUnderDrag,b);d._raiseEvent(p)},onDragEnd:function(){var c=this;c._initializeInnerRail();c._raiseChangeOnlyOnMouseUp&&$common.tryFireEvent(c.get_element(),g);c._innerDrag=b;c._handleUnderDrag=a;c._raiseEvent(q)},get_dropTargetElement:function(){return document.forms[0]},canDrop:function(b,a){return a=="HTML"},drop:Function.emptyMethod,onDragEnterTarget:Function.emptyMethod,onDragLeaveTarget:Function.emptyMethod,onDragInTarget:Function.emptyMethod,_IEDragDropHandler:function(a){a.preventDefault()},_onSelectStart:function(a){a.preventDefault();return b},_getOuterBounds:function(){return this._getBoundsInternal(this._outer)},_getInnerBounds:function(){return this._getBoundsInternal(this._inner)},_getBoundsInternal:function(b){var a=$common.getBounds(b);if(this._isVertical)a={x:a.y,y:a.x,height:a.width,width:a.height,right:a.right,left:a.left,bottom:a.bottom,location:{x:a.y,y:a.x},size:{width:a.height,height:a.width}};else a={x:a.x,y:a.y,height:a.height,width:a.width,right:a.right,left:a.left,bottom:a.bottom,location:{x:a.x,y:a.y},size:{width:a.width,height:a.height}};return a},_raiseEvent:function(c,a){var b=this.get_events().getHandler(c);if(b){if(!a)a=Sys.EventArgs.Empty;b(this,a)}},get_Value:function(){var a=$get(this._boundControlID);return a.value?a.value:0},set_Value:function(c){var a=this,b=$get(a._multiHandleSliderTargets[0].ControlID);a.beginUpdate();a._setMultiHandleSliderTargetValue(b,a._getNearestStepValue(c));a.endUpdate();$common.tryFireEvent(b,g)},get_minimum:function(){return this._minimum},set_minimum:function(a){if(a!==this._minimum){this._minimum=a;this.raisePropertyChanged("minimum")}},get_maximum:function(){return this._maximum},set_maximum:function(a){if(a!==this._maximum){this._maximum=a;this.raisePropertyChanged("maximum")}},get_length:function(){return this._length},set_length:function(a){if(a!==this._length){this._length=a;this.raisePropertyChanged("length")}},get_steps:function(){return this._steps},set_steps:function(c){var a=this,b=a._steps;a._steps=Math.abs(c);a._steps=a._steps===1?2:a._steps;b!==a._steps&&a.raisePropertyChanged("steps")},get_orientation:function(){return this._isVertical},set_orientation:function(a){if(a!==this._isVertical){this._orientation=a;this.raisePropertyChanged("orientation")}},get_enableHandleAnimation:function(){return this._enableHandleAnimation},set_enableHandleAnimation:function(a){if(a!==this._enableHandleAnimation){this._enableHandleAnimation=a;this.raisePropertyChanged("enableHandleAnimation")}},get_handleAnimationDuration:function(){return this._handleAnimationDuration},set_handleAnimationDuration:function(a){if(a!==this._handleAnimationDuration){this._handleAnimationDuration=a;this.raisePropertyChanged("handleAnimationDuration")}},get_raiseChangeOnlyOnMouseUp:function(){return this._raiseChangeOnlyOnMouseUp},set_raiseChangeOnlyOnMouseUp:function(a){if(a!==this._raiseChangeOnlyOnMouseUp){this._raiseChangeOnlyOnMouseUp=a;this.raisePropertyChanged("raiseChangeOnlyOnMouseUp")}},get_showInnerRail:function(){return this._showInnerRail},set_showInnerRail:function(a){if(a!==this._showInnerRail){this._showInnerRail=a;this.raisePropertyChanged("showInnerRail")}},get_showHandleHoverStyle:function(){return this._showHoverStyle},set_showHandleHoverStyle:function(a){if(a!==this._showHoverStyle){this._showHoverStyle=a;this.raisePropertyChanged("showHoverStyle")}},get_showHandleDragStyle:function(){return this._showDragStyle},set_showHandleDragStyle:function(a){if(a!==this._showDragStyle){this._showDragStyle=a;this.raisePropertyChanged("showDragStyle")}},get_innerRailStyle:function(){return this._innerRailStyle},set_innerRailStyle:function(a){if(a!==this._innerRailStyle){this._innerRailStyle=a;this.raisePropertyChanged("innerRailStyle")}},get_enableInnerRangeDrag:function(){return this._enableInnerRangeDrag},set_enableInnerRangeDrag:function(a){if(a!==this._enableInnerRangeDrag){this._enableInnerRangeDrag=a;this.raisePropertyChanged("allowInnerRangeDrag")}},get_enableRailClick:function(){return this._enableRailClick},set_enableRailClick:function(a){if(a!==this._enableRailClick){this._enableRailClick=a;this.raisePropertyChanged("allowRailClick")}},get_isReadOnly:function(){return this._isReadOnly},set_isReadOnly:function(a){if(a!==this._isReadOnly){this._isReadOnly=a;this.raisePropertyChanged("isReadOnly")}},get_enableKeyboard:function(){return this._enableKeyboard},set_enableKeyboard:function(a){if(a!==this._enableKeyboard){this._enableKeyboard=a;this.raisePropertyChanged("enableKeyboard")}},get_enableMouseWheel:function(){return this._enableMouseWheel},set_enableMouseWheel:function(a){if(a!==this._enableMouseWheel){this._enableMouseWheel=a;this.raisePropertyChanged("enableMouseWheel")}},get_increment:function(){return this._increment},set_increment:function(a){if(a!==this._increment){this._increment=a;this.raisePropertyChanged("increment")}},get_tooltipText:function(){return this._tooltipText},set_tooltipText:function(a){if(a!==this._tooltipText){this._tooltipText=a;this.raisePropertyChanged("tooltipText")}},get_multiHandleSliderTargets:function(){return this._multiHandleSliderTargets},set_multiHandleSliderTargets:function(a){if(a!==this._multiHandleSliderTargets){this._multiHandleSliderTargets=a;this.raisePropertyChanged("multiHandleSliderTargets")}},get_cssClass:function(){return this._cssClass},set_cssClass:function(a){if(a!==this._cssClass){this._cssClass=a;this.raisePropertyChanged("cssClass")}},get_boundControlID:function(){return this._boundControlID},set_boundControlID:function(c){var b=this;b._boundControlID=c;if(b._boundControlID)b._boundControl=$get(b._boundControlID);else b._boundControl=a},get_handleCssClass:function(){return this._handleCssClass},set_handleCssClass:function(a){this._handleCssClass=a},get_handleImageUrl:function(){return this._handleImageUrl},set_handleImageUrl:function(a){this._handleImageUrl=a},get_railCssClass:function(){return this._railCssClass},set_railCssClass:function(a){this._railCssClass=a},get_decimals:function(){return this._decimals},set_decimals:function(a){this._decimals=a},add_load:function(a){this.get_events().addHandler(m,a)},remove_load:function(a){this.get_events().removeHandler(m,a)},add_dragStart:function(a){this.get_events().addHandler(o,a)},remove_dragStart:function(a){this.get_events().removeHandler(o,a)},add_drag:function(a){this.get_events().addHandler(p,a)},remove_drag:function(a){this.get_events().removeHandler(p,a)},add_dragEnd:function(a){this.get_events().addHandler(q,a)},remove_dragEnd:function(a){this.get_events().removeHandler(q,a)},add_valueChanged:function(a){this.get_events().addHandler(n,a)},remove_valueChanged:function(a){this.get_events().removeHandler(n,a)}};Sys.Extended.UI.MultiHandleSliderBehavior.DropPending=a;Sys.Extended.UI.MultiHandleSliderBehavior.registerClass("Sys.Extended.UI.MultiHandleSliderBehavior",Sys.Extended.UI.BehaviorBase);Sys.registerComponent(Sys.Extended.UI.MultiHandleSliderBehavior,{name:"multiHandleSlider"})}if(window.Sys&&Sys.loader)Sys.loader.registerScript(b,["ExtendedBase","ExtendedDragDrop","ExtendedAnimations"],a);else a()})();