(window.webpackJsonp=window.webpackJsonp||[]).push([[20],{167:function(e,a,t){"use strict";var n=t(5),r=t(1),c=t.n(r);Object(n.a)({},c.a,{ID:c.a.oneOfType([c.a.string,c.a.number]).isRequired,component:c.a.oneOfType([c.a.string,c.a.func]),date:c.a.oneOfType([c.a.instanceOf(Date),c.a.string])})},172:function(e,a,t){"use strict";var n=t(27),r=t(0),c=t.n(r),o=(t(167),t(28)),s=t(214),l=t(215),i=t(173),u=o.a.create("page"),d=function(e){var a=e.title,t=e.breadcrumbs,r=e.tag,o=e.className,d=e.children,p=Object(n.a)(e,["title","breadcrumbs","tag","className","children"]),f=u.b("px-3",o);return c.a.createElement(r,Object.assign({className:f},p),c.a.createElement("div",{className:u.e("header")},a&&"string"===typeof a?c.a.createElement(i.a,{type:"h1",className:u.e("title")},a):a,t&&c.a.createElement(s.a,{className:u.e("breadcrumb")},t.length&&t.map(function(e,a){var t=e.name,n=e.active;return c.a.createElement(l.a,{key:a,active:n},t)}))),d)};d.defaultProps={tag:"div",title:""},a.a=d},173:function(e,a,t){"use strict";var n=t(36),r=t(27),c=t(7),o=t.n(c),s=t(0),l=t.n(s),i=(t(167),{h1:"h1",h2:"h2",h3:"h3",h4:"h4",h5:"h5",h6:"h6","display-1":"h1","display-2":"h1","display-3":"h1","display-4":"h1",p:"p",lead:"p",blockquote:"blockquote"}),u=function(e){var a,t=e.tag,c=e.className,s=e.type,u=Object(r.a)(e,["tag","className","type"]),d=o()(Object(n.a)({},s,!!s),c);return a=t||(!t&&i[s]?i[s]:"p"),l.a.createElement(a,Object.assign({},u,{className:d}))};u.defaultProps={type:"p"},a.a=u},174:function(e,a,t){"use strict";function n(e,a){return function(e){if(Array.isArray(e))return e}(e)||function(e,a){var t=[],n=!0,r=!1,c=void 0;try{for(var o,s=e[Symbol.iterator]();!(n=(o=s.next()).done)&&(t.push(o.value),!a||t.length!==a);n=!0);}catch(l){r=!0,c=l}finally{try{n||null==s.return||s.return()}finally{if(r)throw c}}return t}(e,a)||function(){throw new TypeError("Invalid attempt to destructure non-iterable instance")}()}t.d(a,"a",function(){return n})},208:function(e,a,t){"use strict";var n=t(4),r=t(6),c=t(0),o=t.n(c),s=t(1),l=t.n(s),i=t(7),u=t.n(i),d=t(3),p={tag:d.m,className:l.a.string,cssModule:l.a.object,innerRef:l.a.oneOfType([l.a.object,l.a.string,l.a.func])},f=function(e){var a=e.className,t=e.cssModule,c=e.innerRef,s=e.tag,l=Object(r.a)(e,["className","cssModule","innerRef","tag"]),i=Object(d.i)(u()(a,"card-body"),t);return o.a.createElement(s,Object(n.a)({},l,{className:i,ref:c}))};f.propTypes=p,f.defaultProps={tag:"div"},a.a=f},214:function(e,a,t){"use strict";var n=t(4),r=t(6),c=t(0),o=t.n(c),s=t(1),l=t.n(s),i=t(7),u=t.n(i),d=t(3),p={tag:d.m,listTag:d.m,className:l.a.string,listClassName:l.a.string,cssModule:l.a.object,children:l.a.node,"aria-label":l.a.string},f=function(e){var a=e.className,t=e.listClassName,c=e.cssModule,s=e.children,l=e.tag,i=e.listTag,p=e["aria-label"],f=Object(r.a)(e,["className","listClassName","cssModule","children","tag","listTag","aria-label"]),m=Object(d.i)(u()(a),c),b=Object(d.i)(u()("breadcrumb",t),c);return o.a.createElement(l,Object(n.a)({},f,{className:m,"aria-label":p}),o.a.createElement(i,{className:b},s))};f.propTypes=p,f.defaultProps={tag:"nav",listTag:"ol","aria-label":"breadcrumb"},a.a=f},215:function(e,a,t){"use strict";var n=t(4),r=t(6),c=t(0),o=t.n(c),s=t(1),l=t.n(s),i=t(7),u=t.n(i),d=t(3),p={tag:d.m,active:l.a.bool,className:l.a.string,cssModule:l.a.object},f=function(e){var a=e.className,t=e.cssModule,c=e.active,s=e.tag,l=Object(r.a)(e,["className","cssModule","active","tag"]),i=Object(d.i)(u()(a,!!c&&"active","breadcrumb-item"),t);return o.a.createElement(s,Object(n.a)({},l,{className:i,"aria-current":c?"page":void 0}))};f.propTypes=p,f.defaultProps={tag:"li"},a.a=f},216:function(e,a,t){"use strict";t.d(a,"d",function(){return l}),t.d(a,"a",function(){return i}),t.d(a,"c",function(){return u}),t.d(a,"b",function(){return d}),t.d(a,"h",function(){return p}),t.d(a,"f",function(){return f}),t.d(a,"g",function(){return m}),t.d(a,"e",function(){return b});var n=t(11),r=t.n(n),c=t(13),o=t(9),s=t(2),l=function(e,a){return function(t){r.a.get("".concat(c.a,"uploads/user")).then(function(a){t({type:s.Q,payload:a.data}),e&&e()}).catch(function(e){a&&(a(),o.b.error("Something went wrong fetching Uploads"))})}},i=function(e,a,t){return function(n){r.a.get("".concat(c.a,"uploads/GetAllFileUploads/").concat(e)).then(function(e){n({type:s.Q,payload:e.data}),a&&a()}).catch(function(e){t&&(t(),o.b.error("Something went wrong fetching Uploads"))})}},u=function(e,a,t){return function(n){r.a.get("".concat(c.a,"uploads/status/").concat(e)).then(function(e){n({type:s.P,payload:e.data}),a&&a()}).catch(function(e){t&&(t(),o.b.error("Something went wrong fetching Uploads"))})}},d=function(e,a,t){return function(n){r.a.get("".concat(c.a,"uploads/").concat(e)).then(function(e){n({type:s.O,payload:e.data}),a&&a()}).catch(function(e){t&&(t(),o.b.error("Something went wrong fetching Upload"))})}},p=function(e,a,t){return function(n){r.a.get("".concat(c.a,"uploads/view/").concat(e)).then(function(e){n({type:s.T,payload:e.data}),a&&a()}).catch(function(e){t&&(t(),o.b.error("Something went wrong fetching Upload"))})}},f=function(e,a,t,n){return function(l){var i=new FormData;i.append("file",a.file),i.append("templateId",a.templateId),i.append("currentUser",a.currentUser),i.append("startDate",a.startDate),i.append("endDate",a.endDate),r.a.post("".concat(c.a,"uploads/upload/").concat(e),i).then(function(e){l({type:s.S,payload:e.data}),t&&t(),o.b.success("File Uploaded Successfully!")}).catch(function(e){l({type:s.M,payload:"Something went wrong"}),n(),console.log(e),o.b.error("Something went wrong")})}},m=function(e,a,t){return function(n){try{var l=new FormData;l.append("file",e.file),l.append("uploadTypeId",e.uploadTypeId),console.log(l),r.a.post("".concat(c.a,"uploads/MER_UPLOAD"),l).then(function(e){n({type:s.S,payload:e.data}),a&&a(),o.b.success("File Uploaded Successfully!")}).catch(function(e){n({type:s.M,payload:"Something went wrong"}),t(),console.log(e),o.b.error("Something went wrong")})}catch(i){}}},b=function(e,a,t,n){return function(l){r.a.put("".concat(c.a,"uploads/review/").concat(e),a).then(function(e){l({type:s.R,payload:e.data}),t&&t(),o.b.success("Saved Successfully!")}).catch(function(e){l({type:s.M,payload:"Something went wrong"}),n(),console.log(e),o.b.error("Something went wrong")})}}},233:function(e,a,t){"use strict";var n=t(4),r=t(6),c=t(0),o=t.n(c),s=t(1),l=t.n(s),i=t(7),u=t.n(i),d=t(3),p={tag:d.m,className:l.a.string,cssModule:l.a.object},f=function(e){var a=e.className,t=e.cssModule,c=e.tag,s=Object(r.a)(e,["className","cssModule","tag"]),l=Object(d.i)(u()(a,"card-header"),t);return o.a.createElement(c,Object(n.a)({},s,{className:l}))};f.propTypes=p,f.defaultProps={tag:"div"},a.a=f},933:function(e,a,t){"use strict";t.r(a);var n=t(174),r=t(32),c=t(0),o=t.n(c),s=t(53),l=t(172),i=t(156),u=t(157),d=t(158),p=t(233),f=t(148),m=t(208),b=t(151),g=t(152),h=t(153),v=t(4),y=t(6),O=t(1),j=t.n(O),E=t(7),w=t.n(E),N=t(3),T={className:j.a.string,cssModule:j.a.object,size:j.a.string,bordered:j.a.bool,borderless:j.a.bool,striped:j.a.bool,inverse:Object(N.f)(j.a.bool,'Please use the prop "dark"'),dark:j.a.bool,hover:j.a.bool,responsive:j.a.oneOfType([j.a.bool,j.a.string]),tag:N.m,responsiveTag:N.m,innerRef:j.a.oneOfType([j.a.func,j.a.string,j.a.object])},S=function(e){var a=e.className,t=e.cssModule,n=e.size,r=e.bordered,c=e.borderless,s=e.striped,l=e.inverse,i=e.dark,u=e.hover,d=e.responsive,p=e.tag,f=e.responsiveTag,m=e.innerRef,b=Object(y.a)(e,["className","cssModule","size","bordered","borderless","striped","inverse","dark","hover","responsive","tag","responsiveTag","innerRef"]),g=Object(N.i)(w()(a,"table",!!n&&"table-"+n,!!r&&"table-bordered",!!c&&"table-borderless",!!s&&"table-striped",!(!i&&!l)&&"table-dark",!!u&&"table-hover"),t),h=o.a.createElement(p,Object(v.a)({},b,{ref:m,className:g}));if(d){var O=!0===d?"table-responsive":"table-responsive-"+d;return o.a.createElement(f,{className:O},h)}return h};S.propTypes=T,S.defaultProps={tag:"table",responsiveTag:"div"};var k=S,M=t(216),U=t(55),D={fetchUpload:M.h};a.default=Object(r.b)(function(e){return{data:e.uploads.view}},D)(function(e){var a=Object(c.useState)(!1),t=Object(n.a)(a,2),r=t[0],v=t[1],y=Object(c.useState)(0),O=Object(n.a)(y,2),j=O[0],E=O[1],N=Object(c.useState)(0),T=Object(n.a)(N,2),S=T[0],M=T[1];Object(c.useEffect)(function(){v(!0);var a=e.match.params;e.fetchUpload(a.id)},[]);return e.data.length>0&&r&&v(!1),o.a.createElement(o.a.Fragment,null,o.a.createElement(l.a,{className:"DashboardPage",hidden:r},o.a.createElement(i.a,null,o.a.createElement(u.a,{xl:12,lg:12,md:12},o.a.createElement(d.a,null,o.a.createElement(p.a,null,"Upload Details",o.a.createElement(s.a,{to:"/review"},o.a.createElement(f.a,{variant:"contained",color:"primary",className:" float-right mr-1"},o.a.createElement("span",{style:{textTransform:"capitalize"}},"Back"))))))),!r&&o.a.createElement(i.a,null,o.a.createElement(u.a,{lg:"12",md:"12",sm:"12",xs:"12"},o.a.createElement(d.a,null,o.a.createElement(p.a,null,"Data"),o.a.createElement(m.a,null,o.a.createElement(b.a,{tabs:!0},e.data.map(function(e,a){var t=e.workSheet;return o.a.createElement(g.a,{key:"nav-Worksheet-".concat(a),className:"nav-tab-details"},o.a.createElement(h.a,{id:"nav-details",className:w()({active:S===a}),onClick:function(){var e;S!==(e=a)&&M(e),function(e){E(e)}(a)}},t))})),o.a.createElement(k,{bordered:!0,responsive:!0},o.a.createElement("thead",null,o.a.createElement("tr",null,e.data.length>0&&Object.keys(e.data[j].data[0]).map(function(e){return o.a.createElement("th",{key:"header-".concat(e)},e)}))),o.a.createElement("tbody",null,e.data.length>0&&Object.values(e.data[j].data).map(function(e,a){return o.a.createElement("tr",{key:"".concat(e[a],"-").concat(a)},Object.entries(e).map(function(e){var a=Object(n.a)(e,2),t=a[0],r=a[1];return o.a.createElement("td",{key:"".concat(t)},r)}))})))))))),r&&o.a.createElement(U.a,null))})}}]);
//# sourceMappingURL=20.3e6bfe8c.chunk.js.map