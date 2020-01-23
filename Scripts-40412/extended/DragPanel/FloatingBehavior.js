// (c) 2010 CodePlex Foundation
(function(){var b="ExtendedFloating";function a(){Sys.Extended.UI.FloatingBehavior=function(n){var f="_floatingObject",e="location",d="mousedown",b=null,c="move",a=this;Sys.Extended.UI.FloatingBehavior.initializeBase(a,[n]);var h,g,j,l,k,i=Function.createDelegate(a,m);a.add_move=function(a){this.get_events().addHandler(c,a)};a.remove_move=function(a){this.get_events().removeHandler(c,a)};a.get_handle=function(){return h};a.set_handle=function(a){h!=b&&$removeHandler(h,d,i);h=a;$addHandler(h,d,i)};a.get_profileProperty=function(){return l};a.set_profileProperty=function(a){l=a};a.get_profileComponent=function(){return k};a.set_profileComponent=function(a){k=a};a.get_location=function(){return g};a.set_location=function(a){if(g!=a){g=a;this.get_isInitialized()&&$common.setLocation(this.get_element(),g);this.raisePropertyChanged(e)}};a.initialize=function(){Sys.Extended.UI.FloatingBehavior.callBaseMethod(this,"initialize");Sys.Extended.UI.DragDropManager.registerDropTarget(this);var a=this.get_element();if(!g)g=$common.getLocation(a);a.style.position="fixed";$common.setLocation(a,g)};a.dispose=function(){Sys.Extended.UI.DragDropManager.unregisterDropTarget(this);h&&i&&$removeHandler(h,d,i);i=b;Sys.Extended.UI.FloatingBehavior.callBaseMethod(this,"dispose")};a.checkCanDrag=function(a){var d=["input","button","select","textarea","label"],c=a.tagName;return c.toLowerCase()=="a"&&a.href!=b&&a.href.length>0?false:Array.indexOf(d,c.toLowerCase())>-1?false:true};function m(a){window._event=a;var b=this.get_element();if(this.checkCanDrag(a.target)){j=$common.getLocation(b);a.preventDefault();this.startDragDrop(b)}}a.get_dragDataType=function(){return f};a.getDragData=function(){return b};a.get_dragMode=function(){return Sys.Extended.UI.DragMode.Move};a.onDragStart=function(){};a.onDrag=function(){};a.onDragEnd=function(b){var a=this;if(!b){var f=a.get_events().getHandler(c);if(f){var d=new Sys.CancelEventArgs;f(a,d);b=d.get_cancel()}}var h=a.get_element();if(b)$common.setLocation(h,j);else{g=$common.getLocation(h);a.raisePropertyChanged(e)}};a.startDragDrop=function(a){Sys.Extended.UI.DragDropManager.startDragDrop(this,a,b)};a.get_dropTargetElement=function(){return document.body};a.canDrop=function(b,a){return a==f};a.drop=function(){};a.onDragEnterTarget=function(){};a.onDragLeaveTarget=function(){};a.onDragInTarget=function(){}};Sys.Extended.UI.FloatingBehavior.registerClass("Sys.Extended.UI.FloatingBehavior",Sys.Extended.UI.BehaviorBase,Sys.Extended.UI.IDragSource,Sys.Extended.UI.IDropTarget,Sys.IDisposable);Sys.registerComponent(Sys.Extended.UI.FloatingBehavior,{name:"draggable"})}if(window.Sys&&Sys.loader)Sys.loader.registerScript(b,["ExtendedBase","ExtendedCommon","ExtendedDragDrop"],a);else a()})();