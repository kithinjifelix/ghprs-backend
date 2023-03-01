(window.webpackJsonp=window.webpackJsonp||[]).push([[28],{169:function(e,a,t){"use strict";var n=t(5),l=t(2),c=t.n(l);Object(n.a)({},c.a,{ID:c.a.oneOfType([c.a.string,c.a.number]).isRequired,component:c.a.oneOfType([c.a.string,c.a.func]),date:c.a.oneOfType([c.a.instanceOf(Date),c.a.string])})},175:function(e,a,t){"use strict";var n=t(28),l=t(1),c=t.n(l),i=(t(169),t(29)),r=t(217),s=t(218),m=t(176),o=i.a.create("page"),u=function(e){var a=e.title,t=e.breadcrumbs,l=e.tag,i=e.className,u=e.children,d=Object(n.a)(e,["title","breadcrumbs","tag","className","children"]),f=o.b("px-3",i);return c.a.createElement(l,Object.assign({className:f},d),c.a.createElement("div",{className:o.e("header")},a&&"string"===typeof a?c.a.createElement(m.a,{type:"h1",className:o.e("title")},a):a,t&&c.a.createElement(r.a,{className:o.e("breadcrumb")},t.length&&t.map(function(e,a){var t=e.name,n=e.active;return c.a.createElement(s.a,{key:a,active:n},t)}))),u)};u.defaultProps={tag:"div",title:""},a.a=u},176:function(e,a,t){"use strict";var n=t(37),l=t(28),c=t(8),i=t.n(c),r=t(1),s=t.n(r),m=(t(169),{h1:"h1",h2:"h2",h3:"h3",h4:"h4",h5:"h5",h6:"h6","display-1":"h1","display-2":"h1","display-3":"h1","display-4":"h1",p:"p",lead:"p",blockquote:"blockquote"}),o=function(e){var a,t=e.tag,c=e.className,r=e.type,o=Object(l.a)(e,["tag","className","type"]),u=i()(Object(n.a)({},r,!!r),c);return a=t||(!t&&m[r]?m[r]:"p"),s.a.createElement(a,Object.assign({},o,{className:u}))};o.defaultProps={type:"p"},a.a=o},941:function(e,a,t){"use strict";t.r(a);var n=t(33),l=t(1),c=t.n(l),i=t(175),r=t(158),s=t(159),m=t(160),o=t(246),u=t(150),d=t(155),f=t(10),p=t(54),E=t(156),b=t(9),h=t(48),g=t(238),k=t.n(g),y=[{id:0,name:"Dashboard"},{id:1,name:"Report"},{id:2,name:"Table"},{id:3,name:"External"}],v={fetchLinks:h.c,remove:h.g};a.default=Object(n.b)(function(e){return{links:e.links.list}},v)(function(e){Object(l.useEffect)(function(){e.fetchLinks()},[]);return c.a.createElement(i.a,{className:"DashboardPage"},c.a.createElement(r.a,null,c.a.createElement(s.a,{xl:12,lg:12,md:12},c.a.createElement(m.a,null,c.a.createElement(o.a,null,"Links",c.a.createElement(p.a,{to:"/administration"},c.a.createElement(u.a,{variant:"contained",color:"link",className:" float-right mr-1"},c.a.createElement(b.c,{size:"15"})," ",c.a.createElement("span",{style:{textTransform:"capitalize"}},"Back"))))))),c.a.createElement(r.a,null,c.a.createElement(s.a,{lg:"12",md:"12",sm:"12",xs:"12"},c.a.createElement(k.a,{columns:[{title:"Name",field:"name"},{title:"URL",field:"url"},{title:"Link Type",field:"type"},{title:"Number",field:"number"},{title:"Actions",field:"actions"}],data:e.links.map(function(a){return{name:a.name,url:a.url,type:y.find(function(e){return e.id===a.linkType}).name,number:a.number,actions:c.a.createElement("div",null,c.a.createElement(d.a,{id:"profile".concat(a.id),tag:E.a,to:"/link/".concat(a.id),activeClassName:"active",exact:!0},c.a.createElement(b.h,{size:"15"})," ",c.a.createElement("span",{style:{color:"#000"}},"Edit")),c.a.createElement(u.a,{size:"sm",color:"link",onClick:function(){return t=a.id,void e.remove(t,function(){f.b.success("Deleted Successfully"),e.fetchLinks()},function(){f.b.error("Something went wrong")});var t}},c.a.createElement(b.f,{size:"15"})," ",c.a.createElement("span",{style:{color:"#000"}},"Delete ")))}}),title:c.a.createElement(p.a,{to:"/link"},c.a.createElement(u.a,{variant:"contained",color:"link",className:" float-right mr-1"},c.a.createElement(b.b,{size:"15"})," ",c.a.createElement("span",{style:{textTransform:"capitalize"}},"Add Link")))}))))})}}]);
//# sourceMappingURL=28.ad425ef8.chunk.js.map