(window.webpackJsonp=window.webpackJsonp||[]).push([[25],{167:function(t,e,n){"use strict";var r=n(4),a=n(1),o=n.n(a);Object(r.a)({},o.a,{ID:o.a.oneOfType([o.a.string,o.a.number]).isRequired,component:o.a.oneOfType([o.a.string,o.a.func]),date:o.a.oneOfType([o.a.instanceOf(Date),o.a.string])})},172:function(t,e,n){"use strict";var r=n(27),a=n(0),o=n.n(a),i=(n(167),n(28)),c=n(215),u=n(216),l=n(173),s=i.a.create("page"),f=function(t){var e=t.title,n=t.breadcrumbs,a=t.tag,i=t.className,f=t.children,h=Object(r.a)(t,["title","breadcrumbs","tag","className","children"]),p=s.b("px-3",i);return o.a.createElement(a,Object.assign({className:p},h),o.a.createElement("div",{className:s.e("header")},e&&"string"===typeof e?o.a.createElement(l.a,{type:"h1",className:s.e("title")},e):e,n&&o.a.createElement(c.a,{className:s.e("breadcrumb")},n.length&&n.map(function(t,e){var n=t.name,r=t.active;return o.a.createElement(u.a,{key:e,active:r},n)}))),f)};f.defaultProps={tag:"div",title:""},e.a=f},173:function(t,e,n){"use strict";var r=n(36),a=n(27),o=n(7),i=n.n(o),c=n(0),u=n.n(c),l=(n(167),{h1:"h1",h2:"h2",h3:"h3",h4:"h4",h5:"h5",h6:"h6","display-1":"h1","display-2":"h1","display-3":"h1","display-4":"h1",p:"p",lead:"p",blockquote:"blockquote"}),s=function(t){var e,n=t.tag,o=t.className,c=t.type,s=Object(a.a)(t,["tag","className","type"]),f=i()(Object(r.a)({},c,!!c),o);return e=n||(!n&&l[c]?l[c]:"p"),u.a.createElement(e,Object.assign({},s,{className:f}))};s.defaultProps={type:"p"},e.a=s},174:function(t,e,n){"use strict";function r(t,e){return function(t){if(Array.isArray(t))return t}(t)||function(t,e){var n=[],r=!0,a=!1,o=void 0;try{for(var i,c=t[Symbol.iterator]();!(r=(i=c.next()).done)&&(n.push(i.value),!e||n.length!==e);r=!0);}catch(u){a=!0,o=u}finally{try{r||null==c.return||c.return()}finally{if(a)throw o}}return n}(t,e)||function(){throw new TypeError("Invalid attempt to destructure non-iterable instance")}()}n.d(e,"a",function(){return r})},217:function(t,e,n){"use strict";n.d(e,"d",function(){return s}),n.d(e,"a",function(){return f}),n.d(e,"c",function(){return h}),n.d(e,"b",function(){return p}),n.d(e,"h",function(){return d}),n.d(e,"f",function(){return y}),n.d(e,"g",function(){return m}),n.d(e,"e",function(){return v});var r=n(191),a=n(11),o=n.n(a),i=n(13),c=n(9),u=n(2);function l(){l=function(){return t};var t={},e=Object.prototype,n=e.hasOwnProperty,r="function"==typeof Symbol?Symbol:{},a=r.iterator||"@@iterator",o=r.asyncIterator||"@@asyncIterator",i=r.toStringTag||"@@toStringTag";function c(t,e,n){return Object.defineProperty(t,e,{value:n,enumerable:!0,configurable:!0,writable:!0}),t[e]}try{c({},"")}catch(S){c=function(t,e,n){return t[e]=n}}function u(t,e,n,r){var a=e&&e.prototype instanceof h?e:h,o=Object.create(a.prototype),i=new L(r||[]);return o._invoke=function(t,e,n){var r="suspendedStart";return function(a,o){if("executing"===r)throw new Error("Generator is already running");if("completed"===r){if("throw"===a)throw o;return N()}for(n.method=a,n.arg=o;;){var i=n.delegate;if(i){var c=E(i,n);if(c){if(c===f)continue;return c}}if("next"===n.method)n.sent=n._sent=n.arg;else if("throw"===n.method){if("suspendedStart"===r)throw r="completed",n.arg;n.dispatchException(n.arg)}else"return"===n.method&&n.abrupt("return",n.arg);r="executing";var u=s(t,e,n);if("normal"===u.type){if(r=n.done?"completed":"suspendedYield",u.arg===f)continue;return{value:u.arg,done:n.done}}"throw"===u.type&&(r="completed",n.method="throw",n.arg=u.arg)}}}(t,n,i),o}function s(t,e,n){try{return{type:"normal",arg:t.call(e,n)}}catch(S){return{type:"throw",arg:S}}}t.wrap=u;var f={};function h(){}function p(){}function d(){}var y={};c(y,a,function(){return this});var m=Object.getPrototypeOf,v=m&&m(m(j([])));v&&v!==e&&n.call(v,a)&&(y=v);var g=d.prototype=h.prototype=Object.create(y);function w(t){["next","throw","return"].forEach(function(e){c(t,e,function(t){return this._invoke(e,t)})})}function b(t,e){var r;this._invoke=function(a,o){function i(){return new e(function(r,i){!function r(a,o,i,c){var u=s(t[a],t,o);if("throw"!==u.type){var l=u.arg,f=l.value;return f&&"object"==typeof f&&n.call(f,"__await")?e.resolve(f.__await).then(function(t){r("next",t,i,c)},function(t){r("throw",t,i,c)}):e.resolve(f).then(function(t){l.value=t,i(l)},function(t){return r("throw",t,i,c)})}c(u.arg)}(a,o,r,i)})}return r=r?r.then(i,i):i()}}function E(t,e){var n=t.iterator[e.method];if(void 0===n){if(e.delegate=null,"throw"===e.method){if(t.iterator.return&&(e.method="return",e.arg=void 0,E(t,e),"throw"===e.method))return f;e.method="throw",e.arg=new TypeError("The iterator does not provide a 'throw' method")}return f}var r=s(n,t.iterator,e.arg);if("throw"===r.type)return e.method="throw",e.arg=r.arg,e.delegate=null,f;var a=r.arg;return a?a.done?(e[t.resultName]=a.value,e.next=t.nextLoc,"return"!==e.method&&(e.method="next",e.arg=void 0),e.delegate=null,f):a:(e.method="throw",e.arg=new TypeError("iterator result is not an object"),e.delegate=null,f)}function x(t){var e={tryLoc:t[0]};1 in t&&(e.catchLoc=t[1]),2 in t&&(e.finallyLoc=t[2],e.afterLoc=t[3]),this.tryEntries.push(e)}function O(t){var e=t.completion||{};e.type="normal",delete e.arg,t.completion=e}function L(t){this.tryEntries=[{tryLoc:"root"}],t.forEach(x,this),this.reset(!0)}function j(t){if(t){var e=t[a];if(e)return e.call(t);if("function"==typeof t.next)return t;if(!isNaN(t.length)){var r=-1,o=function e(){for(;++r<t.length;)if(n.call(t,r))return e.value=t[r],e.done=!1,e;return e.value=void 0,e.done=!0,e};return o.next=o}}return{next:N}}function N(){return{value:void 0,done:!0}}return p.prototype=d,c(g,"constructor",d),c(d,"constructor",p),p.displayName=c(d,i,"GeneratorFunction"),t.isGeneratorFunction=function(t){var e="function"==typeof t&&t.constructor;return!!e&&(e===p||"GeneratorFunction"===(e.displayName||e.name))},t.mark=function(t){return Object.setPrototypeOf?Object.setPrototypeOf(t,d):(t.__proto__=d,c(t,i,"GeneratorFunction")),t.prototype=Object.create(g),t},t.awrap=function(t){return{__await:t}},w(b.prototype),c(b.prototype,o,function(){return this}),t.AsyncIterator=b,t.async=function(e,n,r,a,o){void 0===o&&(o=Promise);var i=new b(u(e,n,r,a),o);return t.isGeneratorFunction(n)?i:i.next().then(function(t){return t.done?t.value:i.next()})},w(g),c(g,i,"Generator"),c(g,a,function(){return this}),c(g,"toString",function(){return"[object Generator]"}),t.keys=function(t){var e=[];for(var n in t)e.push(n);return e.reverse(),function n(){for(;e.length;){var r=e.pop();if(r in t)return n.value=r,n.done=!1,n}return n.done=!0,n}},t.values=j,L.prototype={constructor:L,reset:function(t){if(this.prev=0,this.next=0,this.sent=this._sent=void 0,this.done=!1,this.delegate=null,this.method="next",this.arg=void 0,this.tryEntries.forEach(O),!t)for(var e in this)"t"===e.charAt(0)&&n.call(this,e)&&!isNaN(+e.slice(1))&&(this[e]=void 0)},stop:function(){this.done=!0;var t=this.tryEntries[0].completion;if("throw"===t.type)throw t.arg;return this.rval},dispatchException:function(t){if(this.done)throw t;var e=this;function r(n,r){return i.type="throw",i.arg=t,e.next=n,r&&(e.method="next",e.arg=void 0),!!r}for(var a=this.tryEntries.length-1;a>=0;--a){var o=this.tryEntries[a],i=o.completion;if("root"===o.tryLoc)return r("end");if(o.tryLoc<=this.prev){var c=n.call(o,"catchLoc"),u=n.call(o,"finallyLoc");if(c&&u){if(this.prev<o.catchLoc)return r(o.catchLoc,!0);if(this.prev<o.finallyLoc)return r(o.finallyLoc)}else if(c){if(this.prev<o.catchLoc)return r(o.catchLoc,!0)}else{if(!u)throw new Error("try statement without catch or finally");if(this.prev<o.finallyLoc)return r(o.finallyLoc)}}}},abrupt:function(t,e){for(var r=this.tryEntries.length-1;r>=0;--r){var a=this.tryEntries[r];if(a.tryLoc<=this.prev&&n.call(a,"finallyLoc")&&this.prev<a.finallyLoc){var o=a;break}}o&&("break"===t||"continue"===t)&&o.tryLoc<=e&&e<=o.finallyLoc&&(o=null);var i=o?o.completion:{};return i.type=t,i.arg=e,o?(this.method="next",this.next=o.finallyLoc,f):this.complete(i)},complete:function(t,e){if("throw"===t.type)throw t.arg;return"break"===t.type||"continue"===t.type?this.next=t.arg:"return"===t.type?(this.rval=this.arg=t.arg,this.method="return",this.next="end"):"normal"===t.type&&e&&(this.next=e),f},finish:function(t){for(var e=this.tryEntries.length-1;e>=0;--e){var n=this.tryEntries[e];if(n.finallyLoc===t)return this.complete(n.completion,n.afterLoc),O(n),f}},catch:function(t){for(var e=this.tryEntries.length-1;e>=0;--e){var n=this.tryEntries[e];if(n.tryLoc===t){var r=n.completion;if("throw"===r.type){var a=r.arg;O(n)}return a}}throw new Error("illegal catch attempt")},delegateYield:function(t,e,n){return this.delegate={iterator:j(t),resultName:e,nextLoc:n},"next"===this.method&&(this.arg=void 0),f}},t}var s=function(t,e){return function(n){o.a.get("".concat(i.a,"uploads/user")).then(function(e){n({type:u.R,payload:e.data}),t&&t()}).catch(function(t){e&&(e(),c.b.error("Something went wrong fetching Uploads"))})}},f=function(t,e,n){return function(r){o.a.get("".concat(i.a,"uploads/GetAllFileUploads/").concat(t)).then(function(t){r({type:u.R,payload:t.data}),e&&e()}).catch(function(t){n&&(n(),c.b.error("Something went wrong fetching Uploads"))})}},h=function(t,e,n){return function(r){o.a.get("".concat(i.a,"uploads/status/").concat(t)).then(function(t){r({type:u.Q,payload:t.data}),e&&e()}).catch(function(t){n&&(n(),c.b.error("Something went wrong fetching Uploads"))})}},p=function(t,e,n){return function(r){o.a.get("".concat(i.a,"uploads/").concat(t)).then(function(t){r({type:u.P,payload:t.data}),e&&e()}).catch(function(t){n&&(n(),c.b.error("Something went wrong fetching Upload"))})}},d=function(t,e,n){return function(r){o.a.get("".concat(i.a,"uploads/view/").concat(t)).then(function(t){r({type:u.V,payload:t.data}),e&&e()}).catch(function(t){n&&(n(),c.b.error("Something went wrong fetching Upload"))})}},y=function(t,e,n,r){return function(a){var l=new FormData;l.append("file",e.file),l.append("templateId",e.templateId),l.append("currentUser",e.currentUser),l.append("startDate",e.startDate),l.append("endDate",e.endDate),o.a.post("".concat(i.a,"uploads/upload/").concat(t),l).then(function(t){a({type:u.U,payload:t.data}),n&&n(),c.b.success("File Uploaded Successfully!")}).catch(function(t){a({type:u.N,payload:"Something went wrong"}),r(),console.log(t),c.b.error("Something went wrong")})}},m=function(t,e,n){return function(){var t=Object(r.a)(l().mark(function t(e){return l().wrap(function(t){for(;;)switch(t.prev=t.next){case 0:case 1:case"end":return t.stop()}},t)}));return function(e){return t.apply(this,arguments)}}()},v=function(t,e,n,r){return function(a){o.a.put("".concat(i.a,"uploads/review/").concat(t),e).then(function(t){a({type:u.T,payload:t.data}),n&&n(),c.b.success("Saved Successfully!")}).catch(function(t){a({type:u.N,payload:"Something went wrong"}),r(),console.log(t),c.b.error("Something went wrong")})}}},935:function(t,e,n){"use strict";n.r(e);var r=n(174),a=n(0),o=n.n(a),i=n(217),c=n(32),u=n(172),l=n(156),s=n(157),f=n(158),h=n(241),p=n(209),d=n(151),y=n(152),m=n(153),v=n(242),g=n.n(v),w=(n(13),n(363)),b=n.n(w),E=n(7),x=n.n(E),O={fetchUploads:i.a};e.default=Object(c.b)(function(t){return{uploads:t.uploads.list}},O)(function(t){var e=Object(a.useState)(0),n=Object(r.a)(e,2),i=n[0],c=n[1],v=Object(a.useState)(!1),w=Object(r.a)(v,2),E=(w[0],w[1],Object(a.useState)("Processing")),O=Object(r.a)(E,2),L=O[0],j=O[1];Object(a.useEffect)(function(){t.fetchUploads(L)},[]);var N=function(t){i!==t&&c(t)},S=function(e){j(e),t.fetchUploads(e)};return o.a.createElement(u.a,{className:"DashboardPage"},o.a.createElement(l.a,null,o.a.createElement(s.a,{xl:12,lg:12,md:12},o.a.createElement(f.a,null,o.a.createElement(h.a,null,"Uploads"),o.a.createElement(p.a,null,"MER Data Uploads.")))),o.a.createElement(l.a,null,o.a.createElement(s.a,{lg:"12",md:"12",sm:"12",xs:"12"},o.a.createElement(d.a,{tabs:!0},o.a.createElement(y.a,null,o.a.createElement(m.a,{id:"nav-details",className:x()({active:0===i}),onClick:function(){N(0),S("Processing")}},"Processing")),o.a.createElement(y.a,null,o.a.createElement(m.a,{id:"nav-details",className:x()({active:1===i}),onClick:function(){N(1),S("Completed")}},"Completed")),o.a.createElement(y.a,null,o.a.createElement(m.a,{id:"nav-details",className:x()({active:2===i}),onClick:function(){N(2),S("Error")}},"Error")),o.a.createElement(y.a,null,o.a.createElement(m.a,{id:"nav-details",className:x()({active:3===i}),onClick:function(){N(3),S("Overwritten")}},"Over-Written"))),o.a.createElement(g.a,{columns:[{title:"Name",field:"name"},{title:"Upload Date",field:"date"},{title:"Status",field:"status"},{title:"Content Type",field:"contentType"}],data:t.uploads.map(function(t){return{name:t.name,date:b()(t.createdAt).format("YYYY-MMM-DD"),status:t.status,contentType:"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"==t.contentType?".xlsx":t.contentType}}),title:"Data Submissions"}))))})}}]);
//# sourceMappingURL=25.01101d46.chunk.js.map