(window.webpackJsonp=window.webpackJsonp||[]).push([[8],{167:function(e,a,t){"use strict";var n=t(5),r=t(1),c=t.n(r);Object(n.a)({},c.a,{ID:c.a.oneOfType([c.a.string,c.a.number]).isRequired,component:c.a.oneOfType([c.a.string,c.a.func]),date:c.a.oneOfType([c.a.instanceOf(Date),c.a.string])})},172:function(e,a,t){"use strict";var n=t(27),r=t(0),c=t.n(r),l=(t(167),t(28)),s=t(214),u=t(215),i=t(173),o=l.a.create("page"),m=function(e){var a=e.title,t=e.breadcrumbs,r=e.tag,l=e.className,m=e.children,d=Object(n.a)(e,["title","breadcrumbs","tag","className","children"]),f=o.b("px-3",l);return c.a.createElement(r,Object.assign({className:f},d),c.a.createElement("div",{className:o.e("header")},a&&"string"===typeof a?c.a.createElement(i.a,{type:"h1",className:o.e("title")},a):a,t&&c.a.createElement(s.a,{className:o.e("breadcrumb")},t.length&&t.map(function(e,a){var t=e.name,n=e.active;return c.a.createElement(u.a,{key:a,active:n},t)}))),m)};m.defaultProps={tag:"div",title:""},a.a=m},173:function(e,a,t){"use strict";var n=t(36),r=t(27),c=t(7),l=t.n(c),s=t(0),u=t.n(s),i=(t(167),{h1:"h1",h2:"h2",h3:"h3",h4:"h4",h5:"h5",h6:"h6","display-1":"h1","display-2":"h1","display-3":"h1","display-4":"h1",p:"p",lead:"p",blockquote:"blockquote"}),o=function(e){var a,t=e.tag,c=e.className,s=e.type,o=Object(r.a)(e,["tag","className","type"]),m=l()(Object(n.a)({},s,!!s),c);return a=t||(!t&&i[s]?i[s]:"p"),u.a.createElement(a,Object.assign({},o,{className:m}))};o.defaultProps={type:"p"},a.a=o},654:function(e,a){},656:function(e,a){},670:function(e,a){},672:function(e,a){},700:function(e,a){},702:function(e,a){},703:function(e,a){},708:function(e,a){},710:function(e,a){},716:function(e,a){},718:function(e,a){},737:function(e,a){},749:function(e,a){},752:function(e,a){},914:function(e,a,t){"use strict";t.r(a);var n=t(32),r=t(0),c=t.n(r),l=t(172),s=t(156),u=t(157),i=t(158),o=t(233),m=t(208),d=t(769),f=t(649),h=t(24),b=t(47),p=t(55),g=t(650),E={getDashboard:b.e};a.default=Object(n.b)(function(e){return{currentUser:e.users.currentUser,dashboard:e.links.dashboard}},E)(function(e){var a=window.location.search,t=new URLSearchParams(a),n=t.get("url"),b=t.get("key"),E=t.get("name"),y=parseInt(t.get("number"),10);Object(r.useEffect)(function(){e.getDashboard(y)},[]);return c.a.createElement(c.a.Fragment,null,e.currentUser.organization&&c.a.createElement(l.a,{className:"DashboardPage"},c.a.createElement(s.a,null,c.a.createElement(u.a,{xl:12,lg:12,md:12},c.a.createElement(i.a,null,c.a.createElement(o.a,null,E),c.a.createElement(m.a,null,e.dashboard.description)))),c.a.createElement(s.a,null,c.a.createElement(u.a,{lg:"12",md:"12",sm:"12",xs:"12"},c.a.createElement(i.a,null,c.a.createElement(m.a,null,n&&c.a.createElement(f.a,{src:function(){var a=n,t=b,r="User"===h.a.currentRole?{partner:e.currentUser.organization.name}:{},c={resource:{dashboard:y},params:r,exp:Math.round(Date.now()/1e3)+600},l="";return b&&(l=g.sign(c,t)),a+"/embed/dashboard/"+l+"#bordered=false&titled=true"}(),style:{width:"1px",minWidth:"100%"}}),!n&&c.a.createElement(i.a,null,c.a.createElement(o.a,null,"404"),c.a.createElement(m.a,null,c.a.createElement(d.a,null,"Dashboard not available.")))))))),!e.currentUser.organization&&c.a.createElement(p.a,null))})}}]);
//# sourceMappingURL=8.a7ada2c5.chunk.js.map