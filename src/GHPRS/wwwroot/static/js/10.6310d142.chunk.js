(window.webpackJsonp=window.webpackJsonp||[]).push([[10],{167:function(e,t,a){"use strict";var n=a(5),o=a(1),s=a.n(o);Object(n.a)({},s.a,{ID:s.a.oneOfType([s.a.string,s.a.number]).isRequired,component:s.a.oneOfType([s.a.string,s.a.func]),date:s.a.oneOfType([s.a.instanceOf(Date),s.a.string])})},172:function(e,t,a){"use strict";var n=a(27),o=a(0),s=a.n(o),i=(a(167),a(28)),r=a(214),c=a(215),l=a(173),u=i.a.create("page"),d=function(e){var t=e.title,a=e.breadcrumbs,o=e.tag,i=e.className,d=e.children,p=Object(n.a)(e,["title","breadcrumbs","tag","className","children"]),m=u.b("px-3",i);return s.a.createElement(o,Object.assign({className:m},p),s.a.createElement("div",{className:u.e("header")},t&&"string"===typeof t?s.a.createElement(l.a,{type:"h1",className:u.e("title")},t):t,a&&s.a.createElement(r.a,{className:u.e("breadcrumb")},a.length&&a.map(function(e,t){var a=e.name,n=e.active;return s.a.createElement(c.a,{key:t,active:n},a)}))),d)};d.defaultProps={tag:"div",title:""},t.a=d},173:function(e,t,a){"use strict";var n=a(36),o=a(27),s=a(7),i=a.n(s),r=a(0),c=a.n(r),l=(a(167),{h1:"h1",h2:"h2",h3:"h3",h4:"h4",h5:"h5",h6:"h6","display-1":"h1","display-2":"h1","display-3":"h1","display-4":"h1",p:"p",lead:"p",blockquote:"blockquote"}),u=function(e){var t,a=e.tag,s=e.className,r=e.type,u=Object(o.a)(e,["tag","className","type"]),d=i()(Object(n.a)({},r,!!r),s);return t=a||(!a&&l[r]?l[r]:"p"),c.a.createElement(t,Object.assign({},u,{className:d}))};u.defaultProps={type:"p"},t.a=u},174:function(e,t,a){"use strict";function n(e,t){return function(e){if(Array.isArray(e))return e}(e)||function(e,t){var a=[],n=!0,o=!1,s=void 0;try{for(var i,r=e[Symbol.iterator]();!(n=(i=r.next()).done)&&(a.push(i.value),!t||a.length!==t);n=!0);}catch(c){o=!0,s=c}finally{try{n||null==r.return||r.return()}finally{if(o)throw s}}return a}(e,t)||function(){throw new TypeError("Invalid attempt to destructure non-iterable instance")}()}a.d(t,"a",function(){return n})},191:function(e,t,a){"use strict";var n=a(5),o=a(36),s=a(174),i=a(0);t.a=function(e){var t=Object(i.useState)(e),a=Object(s.a)(t,2),r=a[0],c=a[1],l=Object(i.useState)({}),u=Object(s.a)(l,2),d=u[0],p=u[1];return{values:r,setValues:c,errors:d,setErrors:p,handleInputChange:function(e){var t=e.target,a=t.name,s=t.value,i=Object(o.a)({},a,s);c(Object(n.a)({},r,i))},resetForm:function(){c(e),p({})}}}},208:function(e,t,a){"use strict";var n=a(4),o=a(6),s=a(0),i=a.n(s),r=a(1),c=a.n(r),l=a(7),u=a.n(l),d=a(3),p={tag:d.m,className:c.a.string,cssModule:c.a.object,innerRef:c.a.oneOfType([c.a.object,c.a.string,c.a.func])},m=function(e){var t=e.className,a=e.cssModule,s=e.innerRef,r=e.tag,c=Object(o.a)(e,["className","cssModule","innerRef","tag"]),l=Object(d.i)(u()(t,"card-body"),a);return i.a.createElement(r,Object(n.a)({},c,{className:l,ref:s}))};m.propTypes=p,m.defaultProps={tag:"div"},t.a=m},259:function(e,t,a){"use strict";a.d(t,"d",function(){return c}),a.d(t,"e",function(){return l}),a.d(t,"a",function(){return u}),a.d(t,"i",function(){return d}),a.d(t,"f",function(){return p}),a.d(t,"j",function(){return m}),a.d(t,"g",function(){return f}),a.d(t,"b",function(){return h}),a.d(t,"h",function(){return b}),a.d(t,"c",function(){return g});var n=a(11),o=a.n(n),s=a(13),i=a(9),r=a(2),c=function(e,t){return function(a){o.a.get("".concat(s.a,"templates")).then(function(t){a({type:r.E,payload:t.data}),e&&e()}).catch(function(e){t&&(t(),i.b.error("Something went wrong fetching Templates"))})}},l=function(e,t,a){return function(n){o.a.get("".concat(s.a,"templates/").concat(e)).then(function(e){n({type:r.F,payload:e.data}),t&&t()}).catch(function(e){a&&(a(),i.b.error("Something went wrong fetching Template"))})}},u=function(e,t,a){return function(n){o.a.get("".concat(s.a,"templates/configure/").concat(e)).then(function(e){n({type:r.B,payload:e.data}),t&&t()}).catch(function(e){a&&(a(),i.b.error("Something went wrong!"))})}},d=function(e,t,a,n){return function(c){o.a.put("".concat(s.a,"templates/").concat(e,"/status/").concat(t)).then(function(e){c({type:r.J,payload:e.data}),a&&a()}).catch(function(e){c({type:r.C,payload:"Something went wrong"}),n(),console.log(e),i.b.error("Something went wrong")})}},p=function(e,t,a){return function(n){var c=new FormData;c.append("file",e.file),c.append("name",e.name),c.append("description",e.description),c.append("version",e.version),c.append("frequency",e.frequency),c.append("status",e.status),o.a.post("".concat(s.a,"templates/initialize"),c).then(function(e){n({type:r.G,payload:e.data}),t&&t()}).catch(function(e){n({type:r.C,payload:"Something went wrong"}),a(),console.log(e),i.b.error("Something went wrong")})}},m=function(e,t,a,n){return function(c){var l=new FormData;l.append("file",t.file),o.a.post("".concat(s.a,"templates/updateTemplate/").concat(e),l).then(function(e){c({type:r.H,payload:e.data}),a&&a()}).catch(function(e){c({type:r.I,payload:"Something went wrong"}),n(),console.log(e),i.b.error("Something went wrong")})}},f=function(e,t,a,n){return function(c){o.a.put("".concat(s.a,"templates/workSheet/update/").concat(e),t).then(function(e){a&&a()}).catch(function(e){c({type:r.C,payload:"Something went wrong"}),n(),console.log(e),i.b.error("Something went wrong")})}},h=function(e,t,a){return function(n){o.a.post("".concat(s.a,"templates/tables"),e).then(function(e){t&&t()}).catch(function(e){n({type:r.C,payload:"Something went wrong"}),a(),console.log(e),i.b.error("Something went wrong")})}},b=function(e,t){return function(a){var n={workSheetId:e,name:t.name,type:t.type};a({type:r.K,payload:n})}},g=function(e){return function(t){o.a.get("".concat(s.a,"templates/exists?template=").concat(e)).then(function(e){t({type:r.D,payload:e.data})}).catch(function(e){t({type:r.C,payload:"Something went wrong"}),console.log(e)})}}},276:function(e,t,a){"use strict";var n=a(4),o=a(6),s=a(0),i=a.n(s),r=a(1),c=a.n(r),l=a(7),u=a.n(l),d=a(3),p={children:c.a.node,inline:c.a.bool,tag:d.m,color:c.a.string,className:c.a.string,cssModule:c.a.object},m=function(e){var t=e.className,a=e.cssModule,s=e.inline,r=e.color,c=e.tag,l=Object(o.a)(e,["className","cssModule","inline","color","tag"]),p=Object(d.i)(u()(t,!s&&"form-text",!!r&&"text-"+r),a);return i.a.createElement(c,Object(n.a)({},l,{className:p}))};m.propTypes=p,m.defaultProps={tag:"small",color:"muted"},t.a=m},605:function(e,t,a){"use strict";var n=a(4),o=a(6),s=a(0),i=a.n(s),r=a(1),c=a.n(r),l=a(7),u=a.n(l),d=a(3),p={tag:d.m,wrapTag:d.m,toggle:c.a.func,className:c.a.string,cssModule:c.a.object,children:c.a.node,closeAriaLabel:c.a.string,charCode:c.a.oneOfType([c.a.string,c.a.number]),close:c.a.object},m=function(e){var t,a=e.className,s=e.cssModule,r=e.children,c=e.toggle,l=e.tag,p=e.wrapTag,m=e.closeAriaLabel,f=e.charCode,h=e.close,b=Object(o.a)(e,["className","cssModule","children","toggle","tag","wrapTag","closeAriaLabel","charCode","close"]),g=Object(d.i)(u()(a,"modal-header"),s);if(!h&&c){var y="number"===typeof f?String.fromCharCode(f):f;t=i.a.createElement("button",{type:"button",onClick:c,className:Object(d.i)("close",s),"aria-label":m},i.a.createElement("span",{"aria-hidden":"true"},y))}return i.a.createElement(p,Object(n.a)({},b,{className:g}),i.a.createElement(l,{className:Object(d.i)("modal-title",s)},r),h||t)};m.propTypes=p,m.defaultProps={tag:"h5",wrapTag:"div",closeAriaLabel:"Close",charCode:215},t.a=m},606:function(e,t,a){"use strict";var n=a(4),o=a(6),s=a(0),i=a.n(s),r=a(1),c=a.n(r),l=a(7),u=a.n(l),d=a(3),p={tag:d.m,className:c.a.string,cssModule:c.a.object},m=function(e){var t=e.className,a=e.cssModule,s=e.tag,r=Object(o.a)(e,["className","cssModule","tag"]),c=Object(d.i)(u()(t,"modal-body"),a);return i.a.createElement(s,Object(n.a)({},r,{className:c}))};m.propTypes=p,m.defaultProps={tag:"div"},t.a=m},607:function(e,t,a){"use strict";var n=a(4),o=a(6),s=a(0),i=a.n(s),r=a(1),c=a.n(r),l=a(7),u=a.n(l),d=a(3),p={tag:d.m,className:c.a.string,cssModule:c.a.object},m=function(e){var t=e.className,a=e.cssModule,s=e.tag,r=Object(o.a)(e,["className","cssModule","tag"]),c=Object(d.i)(u()(t,"modal-footer"),a);return i.a.createElement(s,Object(n.a)({},r,{className:c}))};m.propTypes=p,m.defaultProps={tag:"div"},t.a=m},642:function(e,t,a){"use strict";var n=a(38),o=a(4),s=a(23),i=a(12),r=a(0),c=a.n(r),l=a(1),u=a.n(l),d=a(7),p=a.n(d),m=a(15),f=a.n(m),h=a(3),b={children:u.a.node.isRequired,node:u.a.any},g=function(e){function t(){return e.apply(this,arguments)||this}Object(s.a)(t,e);var a=t.prototype;return a.componentWillUnmount=function(){this.defaultNode&&document.body.removeChild(this.defaultNode),this.defaultNode=null},a.render=function(){return h.d?(this.props.node||this.defaultNode||(this.defaultNode=document.createElement("div"),document.body.appendChild(this.defaultNode)),f.a.createPortal(this.props.children,this.props.node||this.defaultNode)):null},t}(c.a.Component);g.propTypes=b;var y=g,O=a(6),E=a(39),v=Object(n.a)({},E.Transition.propTypes,{children:u.a.oneOfType([u.a.arrayOf(u.a.node),u.a.node]),tag:h.m,baseClass:u.a.string,baseClassActive:u.a.string,className:u.a.string,cssModule:u.a.object,innerRef:u.a.oneOfType([u.a.object,u.a.string,u.a.func])}),j=Object(n.a)({},E.Transition.defaultProps,{tag:"div",baseClass:"fade",baseClassActive:"show",timeout:h.c.Fade,appear:!0,enter:!0,exit:!0,in:!0});function C(e){var t=e.tag,a=e.baseClass,n=e.baseClassActive,s=e.className,i=e.cssModule,r=e.children,l=e.innerRef,u=Object(O.a)(e,["tag","baseClass","baseClassActive","className","cssModule","children","innerRef"]),d=Object(h.k)(u,h.a),m=Object(h.j)(u,h.a);return c.a.createElement(E.Transition,d,function(e){var u="entered"===e,d=Object(h.i)(p()(s,a,u&&n),i);return c.a.createElement(t,Object(o.a)({className:d},m,{ref:l}),r)})}C.propTypes=v,C.defaultProps=j;var N=C;function w(){}var T=u.a.shape(N.propTypes),k={isOpen:u.a.bool,autoFocus:u.a.bool,centered:u.a.bool,size:u.a.string,toggle:u.a.func,keyboard:u.a.bool,role:u.a.string,labelledBy:u.a.string,backdrop:u.a.oneOfType([u.a.bool,u.a.oneOf(["static"])]),onEnter:u.a.func,onExit:u.a.func,onOpened:u.a.func,onClosed:u.a.func,children:u.a.node,className:u.a.string,wrapClassName:u.a.string,modalClassName:u.a.string,backdropClassName:u.a.string,contentClassName:u.a.string,external:u.a.node,fade:u.a.bool,cssModule:u.a.object,zIndex:u.a.oneOfType([u.a.number,u.a.string]),backdropTransition:T,modalTransition:T,innerRef:u.a.oneOfType([u.a.object,u.a.string,u.a.func])},S=Object.keys(k),M={isOpen:!1,autoFocus:!0,centered:!1,role:"dialog",backdrop:!0,keyboard:!0,zIndex:1050,fade:!0,onOpened:w,onClosed:w,modalTransition:{timeout:h.c.Modal},backdropTransition:{mountOnEnter:!0,timeout:h.c.Fade}},_=function(e){function t(t){var a;return(a=e.call(this,t)||this)._element=null,a._originalBodyPadding=null,a.getFocusableChildren=a.getFocusableChildren.bind(Object(i.a)(Object(i.a)(a))),a.handleBackdropClick=a.handleBackdropClick.bind(Object(i.a)(Object(i.a)(a))),a.handleBackdropMouseDown=a.handleBackdropMouseDown.bind(Object(i.a)(Object(i.a)(a))),a.handleEscape=a.handleEscape.bind(Object(i.a)(Object(i.a)(a))),a.handleTab=a.handleTab.bind(Object(i.a)(Object(i.a)(a))),a.onOpened=a.onOpened.bind(Object(i.a)(Object(i.a)(a))),a.onClosed=a.onClosed.bind(Object(i.a)(Object(i.a)(a))),a.state={isOpen:t.isOpen},t.isOpen&&a.init(),a}Object(s.a)(t,e);var a=t.prototype;return a.componentDidMount=function(){this.props.onEnter&&this.props.onEnter(),this.state.isOpen&&this.props.autoFocus&&this.setFocus(),this._isMounted=!0},a.componentWillReceiveProps=function(e){e.isOpen&&!this.props.isOpen&&this.setState({isOpen:e.isOpen})},a.componentWillUpdate=function(e,t){t.isOpen&&!this.state.isOpen&&this.init()},a.componentDidUpdate=function(e,t){this.props.autoFocus&&this.state.isOpen&&!t.isOpen&&this.setFocus(),this._element&&e.zIndex!==this.props.zIndex&&(this._element.style.zIndex=this.props.zIndex)},a.componentWillUnmount=function(){this.props.onExit&&this.props.onExit(),this.state.isOpen&&this.destroy(),this._isMounted=!1},a.onOpened=function(e,t){this.props.onOpened(),(this.props.modalTransition.onEntered||w)(e,t)},a.onClosed=function(e){this.props.onClosed(),(this.props.modalTransition.onExited||w)(e),this.destroy(),this._isMounted&&this.setState({isOpen:!1})},a.setFocus=function(){this._dialog&&this._dialog.parentNode&&"function"===typeof this._dialog.parentNode.focus&&this._dialog.parentNode.focus()},a.getFocusableChildren=function(){return this._element.querySelectorAll(h.g.join(", "))},a.getFocusedChild=function(){var e,t=this.getFocusableChildren();try{e=document.activeElement}catch(a){e=t[0]}return e},a.handleBackdropClick=function(e){if(e.target===this._mouseDownElement){if(e.stopPropagation(),!this.props.isOpen||!0!==this.props.backdrop)return;var t=this._dialog?this._dialog.parentNode:null;t&&e.target===t&&this.props.toggle&&this.props.toggle(e)}},a.handleTab=function(e){if(9===e.which){for(var t=this.getFocusableChildren(),a=t.length,n=this.getFocusedChild(),o=0,s=0;s<a;s+=1)if(t[s]===n){o=s;break}e.shiftKey&&0===o?(e.preventDefault(),t[a-1].focus()):e.shiftKey||o!==a-1||(e.preventDefault(),t[0].focus())}},a.handleBackdropMouseDown=function(e){this._mouseDownElement=e.target},a.handleEscape=function(e){this.props.isOpen&&this.props.keyboard&&27===e.keyCode&&this.props.toggle&&(e.preventDefault(),e.stopPropagation(),this.props.toggle(e))},a.init=function(){try{this._triggeringElement=document.activeElement}catch(e){this._triggeringElement=null}this._element=document.createElement("div"),this._element.setAttribute("tabindex","-1"),this._element.style.position="relative",this._element.style.zIndex=this.props.zIndex,this._originalBodyPadding=Object(h.h)(),Object(h.e)(),document.body.appendChild(this._element),0===t.openCount&&(document.body.className=p()(document.body.className,Object(h.i)("modal-open",this.props.cssModule))),t.openCount+=1},a.destroy=function(){if(this._element&&(document.body.removeChild(this._element),this._element=null),this._triggeringElement&&(this._triggeringElement.focus&&this._triggeringElement.focus(),this._triggeringElement=null),t.openCount<=1){var e=Object(h.i)("modal-open",this.props.cssModule),a=new RegExp("(^| )"+e+"( |$)");document.body.className=document.body.className.replace(a," ").trim()}t.openCount-=1,Object(h.l)(this._originalBodyPadding)},a.renderModalDialog=function(){var e,t=this,a=Object(h.j)(this.props,S);return c.a.createElement("div",Object(o.a)({},a,{className:Object(h.i)(p()("modal-dialog",this.props.className,(e={},e["modal-"+this.props.size]=this.props.size,e["modal-dialog-centered"]=this.props.centered,e)),this.props.cssModule),role:"document",ref:function(e){t._dialog=e}}),c.a.createElement("div",{className:Object(h.i)(p()("modal-content",this.props.contentClassName),this.props.cssModule)},this.props.children))},a.render=function(){if(this.state.isOpen){var e=this.props,t=e.wrapClassName,a=e.modalClassName,s=e.backdropClassName,i=e.cssModule,r=e.isOpen,l=e.backdrop,u=e.role,d=e.labelledBy,m=e.external,f=e.innerRef,b={onClick:this.handleBackdropClick,onMouseDown:this.handleBackdropMouseDown,onKeyUp:this.handleEscape,onKeyDown:this.handleTab,style:{display:"block"},"aria-labelledby":d,role:u,tabIndex:"-1"},g=this.props.fade,O=Object(n.a)({},N.defaultProps,this.props.modalTransition,{baseClass:g?this.props.modalTransition.baseClass:"",timeout:g?this.props.modalTransition.timeout:0}),E=Object(n.a)({},N.defaultProps,this.props.backdropTransition,{baseClass:g?this.props.backdropTransition.baseClass:"",timeout:g?this.props.backdropTransition.timeout:0}),v=l&&(g?c.a.createElement(N,Object(o.a)({},E,{in:r&&!!l,cssModule:i,className:Object(h.i)(p()("modal-backdrop",s),i)})):c.a.createElement("div",{className:Object(h.i)(p()("modal-backdrop","show",s),i)}));return c.a.createElement(y,{node:this._element},c.a.createElement("div",{className:Object(h.i)(t)},c.a.createElement(N,Object(o.a)({},b,O,{in:r,onEntered:this.onOpened,onExited:this.onClosed,cssModule:i,className:Object(h.i)(p()("modal",a),i),innerRef:f}),m,this.renderModalDialog()),v))}return null},t}(c.a.Component);_.propTypes=k,_.defaultProps=M,_.openCount=0;t.a=_},923:function(e,t,a){"use strict";a.r(t);var n=a(174),o=a(32),s=a(13),i=a(0),r=a.n(i),c=a(172),l=a(156),u=a(157),d=a(158),p=a(233),m=a(208),f=a(153),h=a(148),b=a(642),g=a(144),y=a(605),O=a(606),E=a(145),v=a(146),j=a(147),C=a(607),N=a(276),w=a(154),T=a(9),k=a(8),S=a(259),M=a(241),_=a.n(M),x=a(24),D=a(191),F=0,z=[{id:0,name:"Not Configured"},{id:1,name:"Active"},{id:2,name:"Archived"}],P=[{name:"Weekly",id:0},{name:"Monthly",id:1},{name:"Quarterly",id:2},{name:"Yearly",id:3},{name:"Adhoc",id:4}],A={status:0},I={updateTemplate:S.j,fetchTemplates:S.d,getTemplate:S.e,updateStatus:S.i};t.default=Object(o.b)(function(e){return{templates:e.templates.list,template:e.templates.template}},I)(function(e){var t=Object(i.useState)(!1),a=Object(n.a)(t,2),o=a[0],S=a[1],M=Object(i.useState)(!1),I=Object(n.a)(M,2),R=I[0],B=I[1],q=Object(i.useState)(),U=Object(n.a)(q,2),K=U[0],W=U[1],L=Object(D.a)(A),J=L.values,V=L.handleInputChange,G=L.resetForm;Object(i.useEffect)(function(){e.fetchTemplates()},[]);var H=function(t){F=t,S(!o),o||e.getTemplate(t)},Q=function(e){F=e,B(!R)};return r.a.createElement(c.a,{className:"DashboardPage"},r.a.createElement(l.a,null,r.a.createElement(u.a,{xl:12,lg:12,md:12},r.a.createElement(d.a,null,r.a.createElement(p.a,null,"Downloads"),r.a.createElement(m.a,null,"Download a blank template to collect and upload data into the system")))),r.a.createElement(l.a,null,r.a.createElement(u.a,{lg:"12",md:"12",sm:"12",xs:"12"},r.a.createElement(_.a,{columns:[{title:"Name",field:"name"},{title:"Description",field:"description"},{title:"Version",field:"version"},{title:"Frequency",field:"frequency"},{title:"Status",field:"status"},{title:"Actions",field:"actions"}],data:e.templates.map(function(e){return{name:e.name,description:e.description,version:e.version,frequency:P.find(function(t){return t.id===e.frequency}).name,status:z.find(function(t){return t.id===e.status}).name,actions:r.a.createElement("div",null,"Administrator"===x.a.currentRole&&0===e.status&&r.a.createElement(f.a,{id:"configure".concat(e.id),tag:w.a,to:"/configure/".concat(e.id),activeClassName:"active",exact:!0},r.a.createElement(k.v,{size:"15"})," ",r.a.createElement("span",{style:{color:"#000"}},"Configure")),r.a.createElement("a",{href:"".concat(s.a,"templates/download/").concat(e.id),target:"_blank",rel:"noopener noreferrer",id:"navItem-".concat(e.name,"-").concat(e.id)},r.a.createElement(k.l,{size:"15"})," ",r.a.createElement("span",{style:{color:"#000"}},"Download")),"Administrator"===x.a.currentRole&&r.a.createElement(h.a,{size:"sm",color:"link",onClick:function(){return H(e.id)}},r.a.createElement(k.s,{size:"15"})," ",r.a.createElement("span",{style:{color:"#000"}},"Status")),"Administrator"===x.a.currentRole&&r.a.createElement(h.a,{size:"sm",color:"link",onClick:function(){return Q(e.id)}},r.a.createElement(k.s,{size:"15"})," ",r.a.createElement("span",{style:{color:"#000"}},"Update Template")))}}),title:"Downloads"}))),r.a.createElement(b.a,{isOpen:o,backdrop:!0},r.a.createElement(g.a,{onSubmit:function(t){t.preventDefault(),e.updateStatus(F,J.status,function(){T.b.success("Status updated successfully"),G(),e.fetchTemplates()},function(){T.b.error("Something went wrong")})}},r.a.createElement(y.a,null,"Update Status"),r.a.createElement(O.a,null,r.a.createElement(E.a,null,r.a.createElement(v.a,{for:"status"},"Status"),r.a.createElement(j.a,{type:"select",name:"status",id:"status",placeholder:"status",value:J.status,onChange:V},r.a.createElement("option",{value:""}," "),z.map(function(e){var t=e.name,a=e.id;return r.a.createElement("option",{key:a,value:a},t)})))),r.a.createElement(C.a,null,r.a.createElement(h.a,{type:"submit",onClick:function(){return H(F)}},"Save"),r.a.createElement(h.a,{onClick:function(){return H(F)}},r.a.createElement("span",{style:{textTransform:"capitalize"}},"Cancel"))))),r.a.createElement(b.a,{isOpen:R,backdrop:!0},r.a.createElement(g.a,{onSubmit:function(t){t.preventDefault(),J.file=K,e.updateTemplate(F,J,function(){T.b.success("Template Updated Successfully")},function(){T.b.error("Something went wrong")})}},r.a.createElement(y.a,null,"Update Template"),r.a.createElement(O.a,null,r.a.createElement(E.a,null,r.a.createElement(v.a,{for:"excelFile"},"File"),r.a.createElement(j.a,{type:"file",name:"file",placeholder:"File",defaultValue:J.file,onChange:function(e){W(e.target.files[0])},accept:"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet, application/vnd.ms-excel"}),r.a.createElement(N.a,{color:"muted"},"Upload filled-out Excel template."))),r.a.createElement(C.a,null,r.a.createElement(h.a,{type:"submit",onClick:function(){return Q(F)}},"Save"),r.a.createElement(h.a,{onClick:function(){return Q(F)}},r.a.createElement("span",{style:{textTransform:"capitalize"}},"Cancel"))))))})}}]);
//# sourceMappingURL=10.6310d142.chunk.js.map