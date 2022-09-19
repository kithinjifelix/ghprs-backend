(window.webpackJsonp=window.webpackJsonp||[]).push([[13],{167:function(e,t,a){"use strict";var n=a(5),c=a(1),r=a.n(c);Object(n.a)({},r.a,{ID:r.a.oneOfType([r.a.string,r.a.number]).isRequired,component:r.a.oneOfType([r.a.string,r.a.func]),date:r.a.oneOfType([r.a.instanceOf(Date),r.a.string])})},172:function(e,t,a){"use strict";var n=a(27),c=a(0),r=a.n(c),o=(a(167),a(28)),l=a(214),i=a(215),s=a(173),u=o.a.create("page"),m=function(e){var t=e.title,a=e.breadcrumbs,c=e.tag,o=e.className,m=e.children,p=Object(n.a)(e,["title","breadcrumbs","tag","className","children"]),d=u.b("px-3",o);return r.a.createElement(c,Object.assign({className:d},p),r.a.createElement("div",{className:u.e("header")},t&&"string"===typeof t?r.a.createElement(s.a,{type:"h1",className:u.e("title")},t):t,a&&r.a.createElement(l.a,{className:u.e("breadcrumb")},a.length&&a.map(function(e,t){var a=e.name,n=e.active;return r.a.createElement(i.a,{key:t,active:n},a)}))),m)};m.defaultProps={tag:"div",title:""},t.a=m},173:function(e,t,a){"use strict";var n=a(36),c=a(27),r=a(7),o=a.n(r),l=a(0),i=a.n(l),s=(a(167),{h1:"h1",h2:"h2",h3:"h3",h4:"h4",h5:"h5",h6:"h6","display-1":"h1","display-2":"h1","display-3":"h1","display-4":"h1",p:"p",lead:"p",blockquote:"blockquote"}),u=function(e){var t,a=e.tag,r=e.className,l=e.type,u=Object(c.a)(e,["tag","className","type"]),m=o()(Object(n.a)({},l,!!l),r);return t=a||(!a&&s[l]?s[l]:"p"),i.a.createElement(t,Object.assign({},u,{className:m}))};u.defaultProps={type:"p"},t.a=u},174:function(e,t,a){"use strict";function n(e,t){return function(e){if(Array.isArray(e))return e}(e)||function(e,t){var a=[],n=!0,c=!1,r=void 0;try{for(var o,l=e[Symbol.iterator]();!(n=(o=l.next()).done)&&(a.push(o.value),!t||a.length!==t);n=!0);}catch(i){c=!0,r=i}finally{try{n||null==l.return||l.return()}finally{if(c)throw r}}return a}(e,t)||function(){throw new TypeError("Invalid attempt to destructure non-iterable instance")}()}a.d(t,"a",function(){return n})},191:function(e,t,a){"use strict";var n=a(5),c=a(36),r=a(174),o=a(0);t.a=function(e){var t=Object(o.useState)(e),a=Object(r.a)(t,2),l=a[0],i=a[1],s=Object(o.useState)({}),u=Object(r.a)(s,2),m=u[0],p=u[1];return{values:l,setValues:i,errors:m,setErrors:p,handleInputChange:function(e){var t=e.target,a=t.name,r=t.value,o=Object(c.a)({},a,r);i(Object(n.a)({},l,o))},resetForm:function(){i(e),p({})}}}},208:function(e,t,a){"use strict";var n=a(4),c=a(6),r=a(0),o=a.n(r),l=a(1),i=a.n(l),s=a(7),u=a.n(s),m=a(3),p={tag:m.m,className:i.a.string,cssModule:i.a.object,innerRef:i.a.oneOfType([i.a.object,i.a.string,i.a.func])},d=function(e){var t=e.className,a=e.cssModule,r=e.innerRef,l=e.tag,i=Object(c.a)(e,["className","cssModule","innerRef","tag"]),s=Object(m.i)(u()(t,"card-body"),a);return o.a.createElement(l,Object(n.a)({},i,{className:s,ref:r}))};d.propTypes=p,d.defaultProps={tag:"div"},t.a=d},214:function(e,t,a){"use strict";var n=a(4),c=a(6),r=a(0),o=a.n(r),l=a(1),i=a.n(l),s=a(7),u=a.n(s),m=a(3),p={tag:m.m,listTag:m.m,className:i.a.string,listClassName:i.a.string,cssModule:i.a.object,children:i.a.node,"aria-label":i.a.string},d=function(e){var t=e.className,a=e.listClassName,r=e.cssModule,l=e.children,i=e.tag,s=e.listTag,p=e["aria-label"],d=Object(c.a)(e,["className","listClassName","cssModule","children","tag","listTag","aria-label"]),f=Object(m.i)(u()(t),r),g=Object(m.i)(u()("breadcrumb",a),r);return o.a.createElement(i,Object(n.a)({},d,{className:f,"aria-label":p}),o.a.createElement(s,{className:g},l))};d.propTypes=p,d.defaultProps={tag:"nav",listTag:"ol","aria-label":"breadcrumb"},t.a=d},215:function(e,t,a){"use strict";var n=a(4),c=a(6),r=a(0),o=a.n(r),l=a(1),i=a.n(l),s=a(7),u=a.n(s),m=a(3),p={tag:m.m,active:i.a.bool,className:i.a.string,cssModule:i.a.object},d=function(e){var t=e.className,a=e.cssModule,r=e.active,l=e.tag,i=Object(c.a)(e,["className","cssModule","active","tag"]),s=Object(m.i)(u()(t,!!r&&"active","breadcrumb-item"),a);return o.a.createElement(l,Object(n.a)({},i,{className:s,"aria-current":r?"page":void 0}))};d.propTypes=p,d.defaultProps={tag:"li"},t.a=d},233:function(e,t,a){"use strict";var n=a(4),c=a(6),r=a(0),o=a.n(r),l=a(1),i=a.n(l),s=a(7),u=a.n(s),m=a(3),p={tag:m.m,className:i.a.string,cssModule:i.a.object},d=function(e){var t=e.className,a=e.cssModule,r=e.tag,l=Object(c.a)(e,["className","cssModule","tag"]),i=Object(m.i)(u()(t,"card-header"),a);return o.a.createElement(r,Object(n.a)({},l,{className:i}))};d.propTypes=p,d.defaultProps={tag:"div"},t.a=d},259:function(e,t,a){"use strict";a.d(t,"d",function(){return i}),a.d(t,"e",function(){return s}),a.d(t,"a",function(){return u}),a.d(t,"i",function(){return m}),a.d(t,"f",function(){return p}),a.d(t,"j",function(){return d}),a.d(t,"g",function(){return f}),a.d(t,"b",function(){return g}),a.d(t,"h",function(){return h}),a.d(t,"c",function(){return b});var n=a(11),c=a.n(n),r=a(13),o=a(9),l=a(2),i=function(e,t){return function(a){c.a.get("".concat(r.a,"templates")).then(function(t){a({type:l.E,payload:t.data}),e&&e()}).catch(function(e){t&&(t(),o.b.error("Something went wrong fetching Templates"))})}},s=function(e,t,a){return function(n){c.a.get("".concat(r.a,"templates/").concat(e)).then(function(e){n({type:l.F,payload:e.data}),t&&t()}).catch(function(e){a&&(a(),o.b.error("Something went wrong fetching Template"))})}},u=function(e,t,a){return function(n){c.a.get("".concat(r.a,"templates/configure/").concat(e)).then(function(e){n({type:l.B,payload:e.data}),t&&t()}).catch(function(e){a&&(a(),o.b.error("Something went wrong!"))})}},m=function(e,t,a,n){return function(i){c.a.put("".concat(r.a,"templates/").concat(e,"/status/").concat(t)).then(function(e){i({type:l.J,payload:e.data}),a&&a()}).catch(function(e){i({type:l.C,payload:"Something went wrong"}),n(),console.log(e),o.b.error("Something went wrong")})}},p=function(e,t,a){return function(n){var i=new FormData;i.append("file",e.file),i.append("name",e.name),i.append("description",e.description),i.append("version",e.version),i.append("frequency",e.frequency),i.append("status",e.status),c.a.post("".concat(r.a,"templates/initialize"),i).then(function(e){n({type:l.G,payload:e.data}),t&&t()}).catch(function(e){n({type:l.C,payload:"Something went wrong"}),a(),console.log(e),o.b.error("Something went wrong")})}},d=function(e,t,a,n){return function(i){var s=new FormData;s.append("file",t.file),c.a.post("".concat(r.a,"templates/updateTemplate/").concat(e),s).then(function(e){i({type:l.H,payload:e.data}),a&&a()}).catch(function(e){i({type:l.I,payload:"Something went wrong"}),n(),console.log(e),o.b.error("Something went wrong")})}},f=function(e,t,a,n){return function(i){c.a.put("".concat(r.a,"templates/workSheet/update/").concat(e),t).then(function(e){a&&a()}).catch(function(e){i({type:l.C,payload:"Something went wrong"}),n(),console.log(e),o.b.error("Something went wrong")})}},g=function(e,t,a){return function(n){c.a.post("".concat(r.a,"templates/tables"),e).then(function(e){t&&t()}).catch(function(e){n({type:l.C,payload:"Something went wrong"}),a(),console.log(e),o.b.error("Something went wrong")})}},h=function(e,t){return function(a){var n={workSheetId:e,name:t.name,type:t.type};a({type:l.K,payload:n})}},b=function(e){return function(t){c.a.get("".concat(r.a,"templates/exists?template=").concat(e)).then(function(e){t({type:l.D,payload:e.data})}).catch(function(e){t({type:l.C,payload:"Something went wrong"}),console.log(e)})}}},276:function(e,t,a){"use strict";var n=a(4),c=a(6),r=a(0),o=a.n(r),l=a(1),i=a.n(l),s=a(7),u=a.n(s),m=a(3),p={children:i.a.node,inline:i.a.bool,tag:m.m,color:i.a.string,className:i.a.string,cssModule:i.a.object},d=function(e){var t=e.className,a=e.cssModule,r=e.inline,l=e.color,i=e.tag,s=Object(c.a)(e,["className","cssModule","inline","color","tag"]),p=Object(m.i)(u()(t,!r&&"form-text",!!l&&"text-"+l),a);return o.a.createElement(i,Object(n.a)({},s,{className:p}))};d.propTypes=p,d.defaultProps={tag:"small",color:"muted"},t.a=d},919:function(e,t,a){"use strict";a.r(t);var n=a(174),c=a(32),r=a(0),o=a.n(r),l=a(172),i=a(156),s=a(157),u=a(158),m=a(233),p=a(208),d=a(144),f=a(145),g=a(146),h=a(147),b=a(276),y=a(148),v=a(259),E=a(9),w=a(191),j=a(55),O={name:"",description:"",version:1,frequency:0,file:""},N={initialize:v.f,exists:v.c};t.default=Object(c.b)(function(e){return{template:e.templates.template,version:e.templates.exists}},N)(function(e){var t=Object(r.useState)(),a=Object(n.a)(t,2),c=a[0],v=a[1],N=Object(r.useState)(!1),S=Object(n.a)(N,2),T=S[0],x=S[1],M=Object(w.a)(O),C=M.values,q=M.handleInputChange,F=M.resetForm;return o.a.createElement(o.a.Fragment,null,o.a.createElement(l.a,{className:"DashboardPage",hidden:T},o.a.createElement(i.a,null,o.a.createElement(s.a,{xl:12,lg:12,md:12},o.a.createElement(u.a,null,o.a.createElement(m.a,null,"Initialize"),o.a.createElement(p.a,null,"Create new templates to allow data upload")))),o.a.createElement(i.a,null,o.a.createElement(s.a,{lg:"12",md:"12",sm:"12",xs:"12"},o.a.createElement(u.a,null,o.a.createElement(p.a,null,o.a.createElement(i.a,null,o.a.createElement(s.a,{md:6},o.a.createElement(d.a,{onSubmit:function(t){t.preventDefault(),x(!0),C.file=c,e.initialize(C,function(){x(!1),E.b.success("Template Initialized"),F(),e.history.push("/configure")},function(){E.b.error("Something went wrong")})}},o.a.createElement(f.a,null,o.a.createElement(g.a,{for:"name"},"Name"),o.a.createElement(h.a,{type:"text",name:"name",placeholder:"Name",defaultValue:C.name,onChange:function(t){q(t),e.exists(t.target.value)}}),o.a.createElement(b.a,{color:"muted"},e.version.item1?"Template version ".concat(e.version.item2," exists. Version ").concat(e.version.item2+1," will be created"):"Version : ".concat(e.version.item2?e.version.item2:1))),o.a.createElement(f.a,null,o.a.createElement(g.a,{for:"description"},"Description"),o.a.createElement(h.a,{type:"text",name:"description",placeholder:"Description",defaultValue:C.description,onChange:q})),o.a.createElement(f.a,null,o.a.createElement(g.a,{for:"frequency"},"Frequency"),o.a.createElement(h.a,{type:"select",name:"frequency",id:"frequency",placeholder:"Select Frequency",value:C.frequency,onChange:q},o.a.createElement("option",{value:""}," "),[{name:"Weekly",id:0},{name:"Monthly",id:1},{name:"Quarterly",id:2},{name:"Yearly",id:3},{name:"Adhoc",id:4}].map(function(e){var t=e.name,a=e.id;return o.a.createElement("option",{key:a,value:a},t)}))),o.a.createElement(f.a,null,o.a.createElement(g.a,{for:"excelFile"},"File"),o.a.createElement(h.a,{type:"file",name:"file",placeholder:"File",defaultValue:C.file,onChange:function(e){v(e.target.files[0])},accept:"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet, application/vnd.ms-excel"}),o.a.createElement(b.a,{color:"muted"},"Upload filled-out Excel template.")),o.a.createElement(f.a,{check:!0,row:!0},o.a.createElement(y.a,null,"Save")))))))))),T&&o.a.createElement(j.a,null))})}}]);
//# sourceMappingURL=13.a63c593f.chunk.js.map