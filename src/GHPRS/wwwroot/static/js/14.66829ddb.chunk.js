(window.webpackJsonp=window.webpackJsonp||[]).push([[14],{167:function(e,a,t){"use strict";var n=t(5),c=t(1),r=t.n(c);Object(n.a)({},r.a,{ID:r.a.oneOfType([r.a.string,r.a.number]).isRequired,component:r.a.oneOfType([r.a.string,r.a.func]),date:r.a.oneOfType([r.a.instanceOf(Date),r.a.string])})},172:function(e,a,t){"use strict";var n=t(27),c=t(0),r=t.n(c),l=(t(167),t(28)),o=t(214),s=t(215),u=t(173),i=l.a.create("page"),d=function(e){var a=e.title,t=e.breadcrumbs,c=e.tag,l=e.className,d=e.children,p=Object(n.a)(e,["title","breadcrumbs","tag","className","children"]),m=i.b("px-3",l);return r.a.createElement(c,Object.assign({className:m},p),r.a.createElement("div",{className:i.e("header")},a&&"string"===typeof a?r.a.createElement(u.a,{type:"h1",className:i.e("title")},a):a,t&&r.a.createElement(o.a,{className:i.e("breadcrumb")},t.length&&t.map(function(e,a){var t=e.name,n=e.active;return r.a.createElement(s.a,{key:a,active:n},t)}))),d)};d.defaultProps={tag:"div",title:""},a.a=d},173:function(e,a,t){"use strict";var n=t(36),c=t(27),r=t(7),l=t.n(r),o=t(0),s=t.n(o),u=(t(167),{h1:"h1",h2:"h2",h3:"h3",h4:"h4",h5:"h5",h6:"h6","display-1":"h1","display-2":"h1","display-3":"h1","display-4":"h1",p:"p",lead:"p",blockquote:"blockquote"}),i=function(e){var a,t=e.tag,r=e.className,o=e.type,i=Object(c.a)(e,["tag","className","type"]),d=l()(Object(n.a)({},o,!!o),r);return a=t||(!t&&u[o]?u[o]:"p"),s.a.createElement(a,Object.assign({},i,{className:d}))};i.defaultProps={type:"p"},a.a=i},174:function(e,a,t){"use strict";function n(e,a){return function(e){if(Array.isArray(e))return e}(e)||function(e,a){var t=[],n=!0,c=!1,r=void 0;try{for(var l,o=e[Symbol.iterator]();!(n=(l=o.next()).done)&&(t.push(l.value),!a||t.length!==a);n=!0);}catch(s){c=!0,r=s}finally{try{n||null==o.return||o.return()}finally{if(c)throw r}}return t}(e,a)||function(){throw new TypeError("Invalid attempt to destructure non-iterable instance")}()}t.d(a,"a",function(){return n})},191:function(e,a,t){"use strict";var n=t(5),c=t(36),r=t(174),l=t(0);a.a=function(e){var a=Object(l.useState)(e),t=Object(r.a)(a,2),o=t[0],s=t[1],u=Object(l.useState)({}),i=Object(r.a)(u,2),d=i[0],p=i[1];return{values:o,setValues:s,errors:d,setErrors:p,handleInputChange:function(e){var a=e.target,t=a.name,r=a.value,l=Object(c.a)({},t,r);s(Object(n.a)({},o,l))},resetForm:function(){s(e),p({})}}}},208:function(e,a,t){"use strict";var n=t(4),c=t(6),r=t(0),l=t.n(r),o=t(1),s=t.n(o),u=t(7),i=t.n(u),d=t(3),p={tag:d.m,className:s.a.string,cssModule:s.a.object,innerRef:s.a.oneOfType([s.a.object,s.a.string,s.a.func])},m=function(e){var a=e.className,t=e.cssModule,r=e.innerRef,o=e.tag,s=Object(c.a)(e,["className","cssModule","innerRef","tag"]),u=Object(d.i)(i()(a,"card-body"),t);return l.a.createElement(o,Object(n.a)({},s,{className:u,ref:r}))};m.propTypes=p,m.defaultProps={tag:"div"},a.a=m},214:function(e,a,t){"use strict";var n=t(4),c=t(6),r=t(0),l=t.n(r),o=t(1),s=t.n(o),u=t(7),i=t.n(u),d=t(3),p={tag:d.m,listTag:d.m,className:s.a.string,listClassName:s.a.string,cssModule:s.a.object,children:s.a.node,"aria-label":s.a.string},m=function(e){var a=e.className,t=e.listClassName,r=e.cssModule,o=e.children,s=e.tag,u=e.listTag,p=e["aria-label"],m=Object(c.a)(e,["className","listClassName","cssModule","children","tag","listTag","aria-label"]),f=Object(d.i)(i()(a),r),g=Object(d.i)(i()("breadcrumb",t),r);return l.a.createElement(s,Object(n.a)({},m,{className:f,"aria-label":p}),l.a.createElement(u,{className:g},o))};m.propTypes=p,m.defaultProps={tag:"nav",listTag:"ol","aria-label":"breadcrumb"},a.a=m},215:function(e,a,t){"use strict";var n=t(4),c=t(6),r=t(0),l=t.n(r),o=t(1),s=t.n(o),u=t(7),i=t.n(u),d=t(3),p={tag:d.m,active:s.a.bool,className:s.a.string,cssModule:s.a.object},m=function(e){var a=e.className,t=e.cssModule,r=e.active,o=e.tag,s=Object(c.a)(e,["className","cssModule","active","tag"]),u=Object(d.i)(i()(a,!!r&&"active","breadcrumb-item"),t);return l.a.createElement(o,Object(n.a)({},s,{className:u,"aria-current":r?"page":void 0}))};m.propTypes=p,m.defaultProps={tag:"li"},a.a=m},216:function(e,a,t){"use strict";t.d(a,"d",function(){return s}),t.d(a,"a",function(){return u}),t.d(a,"c",function(){return i}),t.d(a,"b",function(){return d}),t.d(a,"h",function(){return p}),t.d(a,"f",function(){return m}),t.d(a,"g",function(){return f}),t.d(a,"e",function(){return g});var n=t(11),c=t.n(n),r=t(13),l=t(9),o=t(2),s=function(e,a){return function(t){c.a.get("".concat(r.a,"uploads/user")).then(function(a){t({type:o.Q,payload:a.data}),e&&e()}).catch(function(e){a&&(a(),l.b.error("Something went wrong fetching Uploads"))})}},u=function(e,a,t){return function(n){c.a.get("".concat(r.a,"uploads/GetAllFileUploads/").concat(e)).then(function(e){n({type:o.Q,payload:e.data}),a&&a()}).catch(function(e){t&&(t(),l.b.error("Something went wrong fetching Uploads"))})}},i=function(e,a,t){return function(n){c.a.get("".concat(r.a,"uploads/status/").concat(e)).then(function(e){n({type:o.P,payload:e.data}),a&&a()}).catch(function(e){t&&(t(),l.b.error("Something went wrong fetching Uploads"))})}},d=function(e,a,t){return function(n){c.a.get("".concat(r.a,"uploads/").concat(e)).then(function(e){n({type:o.O,payload:e.data}),a&&a()}).catch(function(e){t&&(t(),l.b.error("Something went wrong fetching Upload"))})}},p=function(e,a,t){return function(n){c.a.get("".concat(r.a,"uploads/view/").concat(e)).then(function(e){n({type:o.T,payload:e.data}),a&&a()}).catch(function(e){t&&(t(),l.b.error("Something went wrong fetching Upload"))})}},m=function(e,a,t,n){return function(s){var u=new FormData;u.append("file",a.file),u.append("templateId",a.templateId),u.append("currentUser",a.currentUser),u.append("startDate",a.startDate),u.append("endDate",a.endDate),c.a.post("".concat(r.a,"uploads/upload/").concat(e),u).then(function(e){s({type:o.S,payload:e.data}),t&&t(),l.b.success("File Uploaded Successfully!")}).catch(function(e){s({type:o.M,payload:"Something went wrong"}),n(),console.log(e),l.b.error("Something went wrong")})}},f=function(e,a,t){return function(n){try{var s=new FormData;s.append("file",e.file),s.append("uploadTypeId",e.uploadTypeId),console.log(s),c.a.post("".concat(r.a,"uploads/MER_UPLOAD"),s).then(function(e){n({type:o.S,payload:e.data}),a&&a(),l.b.success("File Uploaded Successfully!")}).catch(function(e){n({type:o.M,payload:"Something went wrong"}),t(),console.log(e),l.b.error("Something went wrong")})}catch(u){}}},g=function(e,a,t,n){return function(s){c.a.put("".concat(r.a,"uploads/review/").concat(e),a).then(function(e){s({type:o.R,payload:e.data}),t&&t(),l.b.success("Saved Successfully!")}).catch(function(e){s({type:o.M,payload:"Something went wrong"}),n(),console.log(e),l.b.error("Something went wrong")})}}},233:function(e,a,t){"use strict";var n=t(4),c=t(6),r=t(0),l=t.n(r),o=t(1),s=t.n(o),u=t(7),i=t.n(u),d=t(3),p={tag:d.m,className:s.a.string,cssModule:s.a.object},m=function(e){var a=e.className,t=e.cssModule,r=e.tag,o=Object(c.a)(e,["className","cssModule","tag"]),s=Object(d.i)(i()(a,"card-header"),t);return l.a.createElement(r,Object(n.a)({},o,{className:s}))};m.propTypes=p,m.defaultProps={tag:"div"},a.a=m},276:function(e,a,t){"use strict";var n=t(4),c=t(6),r=t(0),l=t.n(r),o=t(1),s=t.n(o),u=t(7),i=t.n(u),d=t(3),p={children:s.a.node,inline:s.a.bool,tag:d.m,color:s.a.string,className:s.a.string,cssModule:s.a.object},m=function(e){var a=e.className,t=e.cssModule,r=e.inline,o=e.color,s=e.tag,u=Object(c.a)(e,["className","cssModule","inline","color","tag"]),p=Object(d.i)(i()(a,!r&&"form-text",!!o&&"text-"+o),t);return l.a.createElement(s,Object(n.a)({},u,{className:p}))};m.propTypes=p,m.defaultProps={tag:"small",color:"muted"},a.a=m},932:function(e,a,t){"use strict";t.r(a);var n=t(174),c=t(32),r=t(0),l=t.n(r),o=t(172),s=t(156),u=t(157),i=t(158),d=t(233),p=t(208),m=t(144),f=t(145),g=t(146),b=t(147),h=t(276),y=t(148),v=t(216),E=t(55),O=t(191),j=t(9),w={file:"",currentUser:"",uploadTypeId:0},N={uploadMERData:v.g};a.default=Object(c.b)(function(e){return{uploadMERData:e.uploads.uploadMERData,currentUser:e.users.currentUser}},N)(function(e){var a=Object(r.useState)(),t=Object(n.a)(a,2),c=t[0],v=t[1],N=Object(r.useState)(!1),M=Object(n.a)(N,2),S=M[0],T=M[1],U=Object(r.useState)(".txt"),D=Object(n.a)(U,2),I=D[0],R=D[1],x=Object(O.a)(w),F=x.values,P=(x.handleInputChange,x.resetForm);return l.a.createElement(l.a.Fragment,null,l.a.createElement(o.a,{className:"DashboardPage",hidden:S},l.a.createElement(s.a,null,l.a.createElement(u.a,{xl:12,lg:12,md:12},l.a.createElement(i.a,null,l.a.createElement(d.a,null,"Submit"),l.a.createElement(p.a,null,"Upload a MER data file")))),l.a.createElement(s.a,null,l.a.createElement(u.a,{lg:"12",md:"12",sm:"12",xs:"12"},l.a.createElement(i.a,null,l.a.createElement(p.a,null,l.a.createElement(m.a,{onSubmit:function(a){T(!0),a.preventDefault(),F.file=c,e.uploadMERData(F,function(){j.b.success("Template uploaded successfully"),P(),T(!1),e.history.push("/files-upload")},function(){j.b.error("Something went wrong"),T(!1)})}},l.a.createElement(s.a,null,l.a.createElement(u.a,{md:4},l.a.createElement(f.a,null,l.a.createElement(g.a,{for:""},"Upload Type"),l.a.createElement(b.a,{type:"select",name:"uploadTypeId",id:"uploadTypeId",placeholder:"Upload Type",onChange:function(e){e.target.value&&(1===Number(e.target.value)?(R(".txt"),w.uploadTypeId=1):2===Number(e.target.value)&&(R("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet, application/vnd.ms-excel"),w.uploadTypeId=2))}},l.a.createElement("option",{value:""}),l.a.createElement("option",{key:"1",value:"1"},"MER DATA UPLOAD"))))),l.a.createElement(s.a,null,l.a.createElement(u.a,{md:4},l.a.createElement(f.a,null,l.a.createElement(g.a,{for:"excelFile"},"File"),l.a.createElement(b.a,{type:"file",name:"file",placeholder:"File",onChange:function(e){v(e.target.files[0])},accept:I}),l.a.createElement(h.a,{color:"muted"},"Upload a MER data file")))),l.a.createElement(s.a,null,l.a.createElement(u.a,{md:4},l.a.createElement(f.a,null,l.a.createElement(g.a,null,"\xa0"),l.a.createElement(y.a,null,"Upload")))))))))),S&&l.a.createElement(E.a,null))})}}]);
//# sourceMappingURL=14.66829ddb.chunk.js.map