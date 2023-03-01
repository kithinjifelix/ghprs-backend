(window.webpackJsonp=window.webpackJsonp||[]).push([[21],{169:function(t,e,n){"use strict";var a=n(5),r=n(2),o=n.n(r);Object(a.a)({},o.a,{ID:o.a.oneOfType([o.a.string,o.a.number]).isRequired,component:o.a.oneOfType([o.a.string,o.a.func]),date:o.a.oneOfType([o.a.instanceOf(Date),o.a.string])})},171:function(t,e,n){"use strict";function a(t,e){return function(t){if(Array.isArray(t))return t}(t)||function(t,e){var n=[],a=!0,r=!1,o=void 0;try{for(var c,i=t[Symbol.iterator]();!(a=(c=i.next()).done)&&(n.push(c.value),!e||n.length!==e);a=!0);}catch(s){r=!0,o=s}finally{try{a||null==i.return||i.return()}finally{if(r)throw o}}return n}(t,e)||function(){throw new TypeError("Invalid attempt to destructure non-iterable instance")}()}n.d(e,"a",function(){return a})},175:function(t,e,n){"use strict";var a=n(28),r=n(1),o=n.n(r),c=(n(169),n(29)),i=n(217),s=n(218),u=n(176),l=c.a.create("page"),f=function(t){var e=t.title,n=t.breadcrumbs,r=t.tag,c=t.className,f=t.children,d=Object(a.a)(t,["title","breadcrumbs","tag","className","children"]),p=l.b("px-3",c);return o.a.createElement(r,Object.assign({className:p},d),o.a.createElement("div",{className:l.e("header")},e&&"string"===typeof e?o.a.createElement(u.a,{type:"h1",className:l.e("title")},e):e,n&&o.a.createElement(i.a,{className:l.e("breadcrumb")},n.length&&n.map(function(t,e){var n=t.name,a=t.active;return o.a.createElement(s.a,{key:e,active:a},n)}))),f)};f.defaultProps={tag:"div",title:""},e.a=f},176:function(t,e,n){"use strict";var a=n(37),r=n(28),o=n(8),c=n.n(o),i=n(1),s=n.n(i),u=(n(169),{h1:"h1",h2:"h2",h3:"h3",h4:"h4",h5:"h5",h6:"h6","display-1":"h1","display-2":"h1","display-3":"h1","display-4":"h1",p:"p",lead:"p",blockquote:"blockquote"}),l=function(t){var e,n=t.tag,o=t.className,i=t.type,l=Object(r.a)(t,["tag","className","type"]),f=c()(Object(a.a)({},i,!!i),o);return e=n||(!n&&u[i]?u[i]:"p"),s.a.createElement(e,Object.assign({},l,{className:f}))};l.defaultProps={type:"p"},e.a=l},178:function(t,e,n){"use strict";function a(t,e,n,a,r,o,c){try{var i=t[o](c),s=i.value}catch(u){return void n(u)}i.done?e(s):Promise.resolve(s).then(a,r)}function r(t){return function(){var e=this,n=arguments;return new Promise(function(r,o){var c=t.apply(e,n);function i(t){a(c,r,o,i,s,"next",t)}function s(t){a(c,r,o,i,s,"throw",t)}i(void 0)})}}n.d(e,"a",function(){return r})},211:function(t,e,n){"use strict";var a=n(6),r=n(7),o=n(1),c=n.n(o),i=n(2),s=n.n(i),u=n(8),l=n.n(u),f=n(4),d={tag:f.m,className:s.a.string,cssModule:s.a.object,innerRef:s.a.oneOfType([s.a.object,s.a.string,s.a.func])},p=function(t){var e=t.className,n=t.cssModule,o=t.innerRef,i=t.tag,s=Object(r.a)(t,["className","cssModule","innerRef","tag"]),u=Object(f.i)(l()(e,"card-body"),n);return c.a.createElement(i,Object(a.a)({},s,{className:u,ref:o}))};p.propTypes=d,p.defaultProps={tag:"div"},e.a=p},217:function(t,e,n){"use strict";var a=n(6),r=n(7),o=n(1),c=n.n(o),i=n(2),s=n.n(i),u=n(8),l=n.n(u),f=n(4),d={tag:f.m,listTag:f.m,className:s.a.string,listClassName:s.a.string,cssModule:s.a.object,children:s.a.node,"aria-label":s.a.string},p=function(t){var e=t.className,n=t.listClassName,o=t.cssModule,i=t.children,s=t.tag,u=t.listTag,d=t["aria-label"],p=Object(r.a)(t,["className","listClassName","cssModule","children","tag","listTag","aria-label"]),h=Object(f.i)(l()(e),o),m=Object(f.i)(l()("breadcrumb",n),o);return c.a.createElement(s,Object(a.a)({},p,{className:h,"aria-label":d}),c.a.createElement(u,{className:m},i))};p.propTypes=d,p.defaultProps={tag:"nav",listTag:"ol","aria-label":"breadcrumb"},e.a=p},218:function(t,e,n){"use strict";var a=n(6),r=n(7),o=n(1),c=n.n(o),i=n(2),s=n.n(i),u=n(8),l=n.n(u),f=n(4),d={tag:f.m,active:s.a.bool,className:s.a.string,cssModule:s.a.object},p=function(t){var e=t.className,n=t.cssModule,o=t.active,i=t.tag,s=Object(r.a)(t,["className","cssModule","active","tag"]),u=Object(f.i)(l()(e,!!o&&"active","breadcrumb-item"),n);return c.a.createElement(i,Object(a.a)({},s,{className:u,"aria-current":o?"page":void 0}))};p.propTypes=d,p.defaultProps={tag:"li"},e.a=p},219:function(t,e,n){"use strict";n.d(e,"e",function(){return l}),n.d(e,"b",function(){return f}),n.d(e,"d",function(){return d}),n.d(e,"c",function(){return p}),n.d(e,"i",function(){return h}),n.d(e,"g",function(){return m}),n.d(e,"h",function(){return v}),n.d(e,"a",function(){return g}),n.d(e,"f",function(){return y});var a=n(178),r=n(12),o=n.n(r),c=n(14),i=n(10),s=n(3);function u(){u=function(){return t};var t={},e=Object.prototype,n=e.hasOwnProperty,a="function"==typeof Symbol?Symbol:{},r=a.iterator||"@@iterator",o=a.asyncIterator||"@@asyncIterator",c=a.toStringTag||"@@toStringTag";function i(t,e,n){return Object.defineProperty(t,e,{value:n,enumerable:!0,configurable:!0,writable:!0}),t[e]}try{i({},"")}catch(k){i=function(t,e,n){return t[e]=n}}function s(t,e,n,a){var r=e&&e.prototype instanceof d?e:d,o=Object.create(r.prototype),c=new N(a||[]);return o._invoke=function(t,e,n){var a="suspendedStart";return function(r,o){if("executing"===a)throw new Error("Generator is already running");if("completed"===a){if("throw"===r)throw o;return S()}for(n.method=r,n.arg=o;;){var c=n.delegate;if(c){var i=E(c,n);if(i){if(i===f)continue;return i}}if("next"===n.method)n.sent=n._sent=n.arg;else if("throw"===n.method){if("suspendedStart"===a)throw a="completed",n.arg;n.dispatchException(n.arg)}else"return"===n.method&&n.abrupt("return",n.arg);a="executing";var s=l(t,e,n);if("normal"===s.type){if(a=n.done?"completed":"suspendedYield",s.arg===f)continue;return{value:s.arg,done:n.done}}"throw"===s.type&&(a="completed",n.method="throw",n.arg=s.arg)}}}(t,n,c),o}function l(t,e,n){try{return{type:"normal",arg:t.call(e,n)}}catch(k){return{type:"throw",arg:k}}}t.wrap=s;var f={};function d(){}function p(){}function h(){}var m={};i(m,r,function(){return this});var v=Object.getPrototypeOf,g=v&&v(v(x([])));g&&g!==e&&n.call(g,r)&&(m=g);var y=h.prototype=d.prototype=Object.create(m);function b(t){["next","throw","return"].forEach(function(e){i(t,e,function(t){return this._invoke(e,t)})})}function w(t,e){var a;this._invoke=function(r,o){function c(){return new e(function(a,c){!function a(r,o,c,i){var s=l(t[r],t,o);if("throw"!==s.type){var u=s.arg,f=u.value;return f&&"object"==typeof f&&n.call(f,"__await")?e.resolve(f.__await).then(function(t){a("next",t,c,i)},function(t){a("throw",t,c,i)}):e.resolve(f).then(function(t){u.value=t,c(u)},function(t){return a("throw",t,c,i)})}i(s.arg)}(r,o,a,c)})}return a=a?a.then(c,c):c()}}function E(t,e){var n=t.iterator[e.method];if(void 0===n){if(e.delegate=null,"throw"===e.method){if(t.iterator.return&&(e.method="return",e.arg=void 0,E(t,e),"throw"===e.method))return f;e.method="throw",e.arg=new TypeError("The iterator does not provide a 'throw' method")}return f}var a=l(n,t.iterator,e.arg);if("throw"===a.type)return e.method="throw",e.arg=a.arg,e.delegate=null,f;var r=a.arg;return r?r.done?(e[t.resultName]=r.value,e.next=t.nextLoc,"return"!==e.method&&(e.method="next",e.arg=void 0),e.delegate=null,f):r:(e.method="throw",e.arg=new TypeError("iterator result is not an object"),e.delegate=null,f)}function O(t){var e={tryLoc:t[0]};1 in t&&(e.catchLoc=t[1]),2 in t&&(e.finallyLoc=t[2],e.afterLoc=t[3]),this.tryEntries.push(e)}function j(t){var e=t.completion||{};e.type="normal",delete e.arg,t.completion=e}function N(t){this.tryEntries=[{tryLoc:"root"}],t.forEach(O,this),this.reset(!0)}function x(t){if(t){var e=t[r];if(e)return e.call(t);if("function"==typeof t.next)return t;if(!isNaN(t.length)){var a=-1,o=function e(){for(;++a<t.length;)if(n.call(t,a))return e.value=t[a],e.done=!1,e;return e.value=void 0,e.done=!0,e};return o.next=o}}return{next:S}}function S(){return{value:void 0,done:!0}}return p.prototype=h,i(y,"constructor",h),i(h,"constructor",p),p.displayName=i(h,c,"GeneratorFunction"),t.isGeneratorFunction=function(t){var e="function"==typeof t&&t.constructor;return!!e&&(e===p||"GeneratorFunction"===(e.displayName||e.name))},t.mark=function(t){return Object.setPrototypeOf?Object.setPrototypeOf(t,h):(t.__proto__=h,i(t,c,"GeneratorFunction")),t.prototype=Object.create(y),t},t.awrap=function(t){return{__await:t}},b(w.prototype),i(w.prototype,o,function(){return this}),t.AsyncIterator=w,t.async=function(e,n,a,r,o){void 0===o&&(o=Promise);var c=new w(s(e,n,a,r),o);return t.isGeneratorFunction(n)?c:c.next().then(function(t){return t.done?t.value:c.next()})},b(y),i(y,c,"Generator"),i(y,r,function(){return this}),i(y,"toString",function(){return"[object Generator]"}),t.keys=function(t){var e=[];for(var n in t)e.push(n);return e.reverse(),function n(){for(;e.length;){var a=e.pop();if(a in t)return n.value=a,n.done=!1,n}return n.done=!0,n}},t.values=x,N.prototype={constructor:N,reset:function(t){if(this.prev=0,this.next=0,this.sent=this._sent=void 0,this.done=!1,this.delegate=null,this.method="next",this.arg=void 0,this.tryEntries.forEach(j),!t)for(var e in this)"t"===e.charAt(0)&&n.call(this,e)&&!isNaN(+e.slice(1))&&(this[e]=void 0)},stop:function(){this.done=!0;var t=this.tryEntries[0].completion;if("throw"===t.type)throw t.arg;return this.rval},dispatchException:function(t){if(this.done)throw t;var e=this;function a(n,a){return c.type="throw",c.arg=t,e.next=n,a&&(e.method="next",e.arg=void 0),!!a}for(var r=this.tryEntries.length-1;r>=0;--r){var o=this.tryEntries[r],c=o.completion;if("root"===o.tryLoc)return a("end");if(o.tryLoc<=this.prev){var i=n.call(o,"catchLoc"),s=n.call(o,"finallyLoc");if(i&&s){if(this.prev<o.catchLoc)return a(o.catchLoc,!0);if(this.prev<o.finallyLoc)return a(o.finallyLoc)}else if(i){if(this.prev<o.catchLoc)return a(o.catchLoc,!0)}else{if(!s)throw new Error("try statement without catch or finally");if(this.prev<o.finallyLoc)return a(o.finallyLoc)}}}},abrupt:function(t,e){for(var a=this.tryEntries.length-1;a>=0;--a){var r=this.tryEntries[a];if(r.tryLoc<=this.prev&&n.call(r,"finallyLoc")&&this.prev<r.finallyLoc){var o=r;break}}o&&("break"===t||"continue"===t)&&o.tryLoc<=e&&e<=o.finallyLoc&&(o=null);var c=o?o.completion:{};return c.type=t,c.arg=e,o?(this.method="next",this.next=o.finallyLoc,f):this.complete(c)},complete:function(t,e){if("throw"===t.type)throw t.arg;return"break"===t.type||"continue"===t.type?this.next=t.arg:"return"===t.type?(this.rval=this.arg=t.arg,this.method="return",this.next="end"):"normal"===t.type&&e&&(this.next=e),f},finish:function(t){for(var e=this.tryEntries.length-1;e>=0;--e){var n=this.tryEntries[e];if(n.finallyLoc===t)return this.complete(n.completion,n.afterLoc),j(n),f}},catch:function(t){for(var e=this.tryEntries.length-1;e>=0;--e){var n=this.tryEntries[e];if(n.tryLoc===t){var a=n.completion;if("throw"===a.type){var r=a.arg;j(n)}return r}}throw new Error("illegal catch attempt")},delegateYield:function(t,e,n){return this.delegate={iterator:x(t),resultName:e,nextLoc:n},"next"===this.method&&(this.arg=void 0),f}},t}var l=function(t,e){return function(n){o.a.get("".concat(c.b,"uploads/user")).then(function(e){n({type:s.S,payload:e.data}),t&&t()}).catch(function(t){e&&(e(),i.b.error("Something went wrong fetching Uploads"))})}},f=function(t,e,n){return function(a){o.a.get("".concat(c.b,"uploads/GetAllFileUploads/").concat(t)).then(function(t){a({type:s.S,payload:t.data}),e&&e()}).catch(function(t){n&&(n(),i.b.error("Something went wrong fetching Uploads"))})}},d=function(t,e,n){return function(a){o.a.get("".concat(c.b,"uploads/status/").concat(t)).then(function(t){a({type:s.R,payload:t.data}),e&&e()}).catch(function(t){n&&(n(),i.b.error("Something went wrong fetching Uploads"))})}},p=function(t,e,n){return function(a){o.a.get("".concat(c.b,"uploads/").concat(t)).then(function(t){a({type:s.Q,payload:t.data}),e&&e()}).catch(function(t){n&&(n(),i.b.error("Something went wrong fetching Upload"))})}},h=function(t,e,n){return function(a){o.a.get("".concat(c.b,"uploads/view/").concat(t)).then(function(t){a({type:s.W,payload:t.data}),e&&e()}).catch(function(t){n&&(n(),i.b.error("Something went wrong fetching Upload"))})}},m=function(t,e,n,a){return function(r){var u=new FormData;u.append("file",e.file),u.append("templateId",e.templateId),u.append("currentUser",e.currentUser),u.append("startDate",e.startDate),u.append("endDate",e.endDate),o.a.post("".concat(c.b,"uploads/upload/").concat(t),u).then(function(t){r({type:s.V,payload:t.data}),n&&n(),i.b.success("File Uploaded Successfully!")}).catch(function(t){r({type:s.O,payload:"Something went wrong"}),a(),console.log(t),i.b.error("Something went wrong")})}},v=function(t,e,n){return function(){var t=Object(a.a)(u().mark(function t(a){return u().wrap(function(t){for(;;)switch(t.prev=t.next){case 0:try{o.a.get("".concat(c.b,"uploads/MER_UPLOAD")).then(function(t){a({type:s.x,payload:t.data}),e&&e()}).catch(function(t){n&&(n(),i.b.error("Something went wrong fetching Upload"))})}catch(r){a({type:s.O,payload:"Something went wrong"}),n()}case 1:case"end":return t.stop()}},t)}));return function(e){return t.apply(this,arguments)}}()},g=function(t,e,n,r){return function(){var s=Object(a.a)(u().mark(function a(s){var l;return u().wrap(function(a){for(;;)switch(a.prev=a.next){case 0:(l=new FormData).append("name",t),o()({method:"post",url:"".concat(c.b,"uploads/ProcessBlob/").concat(e.fileType),data:l}).then(function(t){n&&n(),i.b.success("Saved Successfully!")}).catch(function(t){r(),console.log(t),i.b.error("Something went wrong")});case 3:case"end":return a.stop()}},a)}));return function(t){return s.apply(this,arguments)}}()},y=function(t,e,n,a){return function(r){o.a.put("".concat(c.b,"uploads/review/").concat(t),e).then(function(t){r({type:s.U,payload:t.data}),n&&n(),i.b.success("Saved Successfully!")}).catch(function(t){r({type:s.O,payload:"Something went wrong"}),a(),console.log(t),i.b.error("Something went wrong")})}}},246:function(t,e,n){"use strict";var a=n(6),r=n(7),o=n(1),c=n.n(o),i=n(2),s=n.n(i),u=n(8),l=n.n(u),f=n(4),d={tag:f.m,className:s.a.string,cssModule:s.a.object},p=function(t){var e=t.className,n=t.cssModule,o=t.tag,i=Object(r.a)(t,["className","cssModule","tag"]),s=Object(f.i)(l()(e,"card-header"),n);return c.a.createElement(o,Object(a.a)({},i,{className:s}))};p.propTypes=d,p.defaultProps={tag:"div"},e.a=p},947:function(t,e,n){"use strict";n.r(e);var a=n(171),r=n(33),o=n(1),c=n.n(o),i=n(54),s=n(175),u=n(158),l=n(159),f=n(160),d=n(246),p=n(150),h=n(211),m=n(153),v=n(154),g=n(155),y=n(6),b=n(7),w=n(2),E=n.n(w),O=n(8),j=n.n(O),N=n(4),x={className:E.a.string,cssModule:E.a.object,size:E.a.string,bordered:E.a.bool,borderless:E.a.bool,striped:E.a.bool,inverse:Object(N.f)(E.a.bool,'Please use the prop "dark"'),dark:E.a.bool,hover:E.a.bool,responsive:E.a.oneOfType([E.a.bool,E.a.string]),tag:N.m,responsiveTag:N.m,innerRef:E.a.oneOfType([E.a.func,E.a.string,E.a.object])},S=function(t){var e=t.className,n=t.cssModule,a=t.size,r=t.bordered,o=t.borderless,i=t.striped,s=t.inverse,u=t.dark,l=t.hover,f=t.responsive,d=t.tag,p=t.responsiveTag,h=t.innerRef,m=Object(b.a)(t,["className","cssModule","size","bordered","borderless","striped","inverse","dark","hover","responsive","tag","responsiveTag","innerRef"]),v=Object(N.i)(j()(e,"table",!!a&&"table-"+a,!!r&&"table-bordered",!!o&&"table-borderless",!!i&&"table-striped",!(!u&&!s)&&"table-dark",!!l&&"table-hover"),n),g=c.a.createElement(d,Object(y.a)({},m,{ref:h,className:v}));if(f){var w=!0===f?"table-responsive":"table-responsive-"+f;return c.a.createElement(p,{className:w},g)}return g};S.propTypes=x,S.defaultProps={tag:"table",responsiveTag:"div"};var k=S,L=n(219),T=n(56),P={fetchUpload:L.i};e.default=Object(r.b)(function(t){return{data:t.uploads.view}},P)(function(t){var e=Object(o.useState)(!1),n=Object(a.a)(e,2),r=n[0],y=n[1],b=Object(o.useState)(0),w=Object(a.a)(b,2),E=w[0],O=w[1],N=Object(o.useState)(0),x=Object(a.a)(N,2),S=x[0],L=x[1];Object(o.useEffect)(function(){y(!0);var e=t.match.params;t.fetchUpload(e.id)},[]);return t.data.length>0&&r&&y(!1),c.a.createElement(c.a.Fragment,null,c.a.createElement(s.a,{className:"DashboardPage",hidden:r},c.a.createElement(u.a,null,c.a.createElement(l.a,{xl:12,lg:12,md:12},c.a.createElement(f.a,null,c.a.createElement(d.a,null,"Upload Details",c.a.createElement(i.a,{to:"/review"},c.a.createElement(p.a,{variant:"contained",color:"primary",className:" float-right mr-1"},c.a.createElement("span",{style:{textTransform:"capitalize"}},"Back"))))))),!r&&c.a.createElement(u.a,null,c.a.createElement(l.a,{lg:"12",md:"12",sm:"12",xs:"12"},c.a.createElement(f.a,null,c.a.createElement(d.a,null,"Data"),c.a.createElement(h.a,null,c.a.createElement(m.a,{tabs:!0},t.data.map(function(t,e){var n=t.workSheet;return c.a.createElement(v.a,{key:"nav-Worksheet-".concat(e),className:"nav-tab-details"},c.a.createElement(g.a,{id:"nav-details",className:j()({active:S===e}),onClick:function(){var t;S!==(t=e)&&L(t),function(t){O(t)}(e)}},n))})),c.a.createElement(k,{bordered:!0,responsive:!0},c.a.createElement("thead",null,c.a.createElement("tr",null,t.data.length>0&&t.data[E]&&t.data[E].data[0]&&Object.keys(t.data[E].data[0]).map(function(t){return c.a.createElement("th",{key:"header-".concat(t)},t)}))),c.a.createElement("tbody",null,t.data.length>0&&Object.values(t.data[E].data).map(function(t,e){return c.a.createElement("tr",{key:"".concat(t[e],"-").concat(e)},Object.entries(t).map(function(t){var e=Object(a.a)(t,2),n=e[0],r=e[1];return c.a.createElement("td",{key:"".concat(n)},r)}))})))))))),r&&c.a.createElement(T.a,null))})}}]);
//# sourceMappingURL=21.807a1c4d.chunk.js.map