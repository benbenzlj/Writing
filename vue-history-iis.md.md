---


---

<h2 id="vueroute使用history模式">VueRoute使用history模式</h2>
<h3 id="开发模式">开发模式</h3>
<ul>
<li>修改路由</li>
</ul>
<pre class=" language-javascript"><code class="prism  language-javascript"><span class="token keyword">const</span> router <span class="token operator">=</span> <span class="token keyword">new</span> <span class="token class-name">VueRouter</span><span class="token punctuation">(</span><span class="token punctuation">{</span>
  base<span class="token punctuation">:</span> <span class="token string">'/survey/'</span><span class="token punctuation">,</span> <span class="token operator">--</span>多页面要配置这里，搞好几天才搞明白
  mode<span class="token punctuation">:</span> <span class="token string">'history'</span><span class="token punctuation">,</span> 
  routes
<span class="token punctuation">}</span><span class="token punctuation">)</span>
</code></pre>
<ul>
<li>使用 <code>connect-history-api-fallback</code>组件</li>
<li>配置rewrites</li>
</ul>
<pre class=" language-javascript"><code class="prism  language-javascript"><span class="token keyword">let</span> rewrites <span class="token operator">=</span> Object<span class="token punctuation">.</span><span class="token function">keys</span><span class="token punctuation">(</span>utils<span class="token punctuation">.</span><span class="token function">getEntries</span><span class="token punctuation">(</span><span class="token string">'./src/pages/**/app.js'</span><span class="token punctuation">)</span><span class="token punctuation">)</span>
    <span class="token punctuation">.</span><span class="token function">map</span><span class="token punctuation">(</span><span class="token keyword">function</span> <span class="token punctuation">(</span>entry<span class="token punctuation">)</span> <span class="token punctuation">{</span>
        <span class="token keyword">return</span> <span class="token punctuation">{</span>
            <span class="token keyword">from</span><span class="token punctuation">:</span> <span class="token keyword">new</span> <span class="token class-name">RegExp</span><span class="token punctuation">(</span><span class="token string">'/'</span> <span class="token operator">+</span> entry<span class="token punctuation">)</span><span class="token punctuation">,</span>
            to<span class="token punctuation">:</span> <span class="token string">'/'</span> <span class="token operator">+</span> entry <span class="token operator">+</span> <span class="token string">'/index.html'</span>
        <span class="token punctuation">}</span><span class="token punctuation">;</span>
    <span class="token punctuation">}</span><span class="token punctuation">)</span><span class="token punctuation">;</span>
console<span class="token punctuation">.</span><span class="token function">log</span><span class="token punctuation">(</span>rewrites<span class="token punctuation">)</span>
<span class="token keyword">var</span> history <span class="token operator">=</span> <span class="token function">require</span><span class="token punctuation">(</span><span class="token string">'connect-history-api-fallback'</span><span class="token punctuation">)</span>
app<span class="token punctuation">.</span><span class="token function">use</span><span class="token punctuation">(</span><span class="token function">history</span><span class="token punctuation">(</span><span class="token punctuation">{</span>
  <span class="token comment">//index: '/survey/index.html',</span>
  rewrites<span class="token punctuation">,</span>
  verbose<span class="token punctuation">:</span> <span class="token boolean">true</span><span class="token punctuation">,</span>
  disableDotRule<span class="token punctuation">:</span> <span class="token boolean">true</span><span class="token punctuation">,</span>
  htmlAcceptHeaders<span class="token punctuation">:</span> <span class="token punctuation">[</span><span class="token string">'text/html'</span><span class="token punctuation">,</span> <span class="token string">'application/xhtml+xml'</span><span class="token punctuation">]</span><span class="token punctuation">,</span>
  logger<span class="token punctuation">:</span> console<span class="token punctuation">.</span>log<span class="token punctuation">.</span><span class="token function">bind</span><span class="token punctuation">(</span>console<span class="token punctuation">)</span>
<span class="token punctuation">}</span><span class="token punctuation">)</span><span class="token punctuation">)</span>
</code></pre>
<h3 id="生产环境iis配置">生产环境IIS配置</h3>
<ul>
<li>安装<code>IIS URLRewriter</code> 插件</li>
<li>根目录下增加配置文件<code>web.config</code>,内容如下</li>
</ul>
<pre class=" language-xml"><code class="prism  language-xml"><span class="token prolog">&lt;?xml version="1.0" encoding="UTF-8"?&gt;</span>
<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>configuration</span><span class="token punctuation">&gt;</span></span>
  <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>system.webServer</span><span class="token punctuation">&gt;</span></span>
    <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>rewrite</span><span class="token punctuation">&gt;</span></span>
      <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>rules</span><span class="token punctuation">&gt;</span></span>
        <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>rule</span> <span class="token attr-name">name</span><span class="token attr-value"><span class="token punctuation">=</span><span class="token punctuation">"</span>survey<span class="token punctuation">"</span></span> <span class="token attr-name">stopProcessing</span><span class="token attr-value"><span class="token punctuation">=</span><span class="token punctuation">"</span>true<span class="token punctuation">"</span></span><span class="token punctuation">&gt;</span></span>
          <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>match</span> <span class="token attr-name">url</span><span class="token attr-value"><span class="token punctuation">=</span><span class="token punctuation">"</span>(^survey/.*)<span class="token punctuation">"</span></span> <span class="token punctuation">/&gt;</span></span>
          <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>conditions</span> <span class="token attr-name">logicalGrouping</span><span class="token attr-value"><span class="token punctuation">=</span><span class="token punctuation">"</span>MatchAll<span class="token punctuation">"</span></span><span class="token punctuation">&gt;</span></span>
            <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>add</span> <span class="token attr-name">input</span><span class="token attr-value"><span class="token punctuation">=</span><span class="token punctuation">"</span>{REQUEST_FILENAME}<span class="token punctuation">"</span></span> <span class="token attr-name">matchType</span><span class="token attr-value"><span class="token punctuation">=</span><span class="token punctuation">"</span>IsFile<span class="token punctuation">"</span></span> <span class="token attr-name">negate</span><span class="token attr-value"><span class="token punctuation">=</span><span class="token punctuation">"</span>true<span class="token punctuation">"</span></span> <span class="token punctuation">/&gt;</span></span>
            <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>add</span> <span class="token attr-name">input</span><span class="token attr-value"><span class="token punctuation">=</span><span class="token punctuation">"</span>{REQUEST_FILENAME}<span class="token punctuation">"</span></span> <span class="token attr-name">matchType</span><span class="token attr-value"><span class="token punctuation">=</span><span class="token punctuation">"</span>IsDirectory<span class="token punctuation">"</span></span> <span class="token attr-name">negate</span><span class="token attr-value"><span class="token punctuation">=</span><span class="token punctuation">"</span>true<span class="token punctuation">"</span></span> <span class="token punctuation">/&gt;</span></span>
          <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>conditions</span><span class="token punctuation">&gt;</span></span>
          <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>action</span> <span class="token attr-name">type</span><span class="token attr-value"><span class="token punctuation">=</span><span class="token punctuation">"</span>Rewrite<span class="token punctuation">"</span></span> <span class="token attr-name">url</span><span class="token attr-value"><span class="token punctuation">=</span><span class="token punctuation">"</span>/index.html<span class="token punctuation">"</span></span> <span class="token punctuation">/&gt;</span></span>
        <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>rule</span><span class="token punctuation">&gt;</span></span>
        <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>rule</span> <span class="token attr-name">name</span><span class="token attr-value"><span class="token punctuation">=</span><span class="token punctuation">"</span>answer<span class="token punctuation">"</span></span> <span class="token attr-name">stopProcessing</span><span class="token attr-value"><span class="token punctuation">=</span><span class="token punctuation">"</span>true<span class="token punctuation">"</span></span><span class="token punctuation">&gt;</span></span>
          <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>match</span> <span class="token attr-name">url</span><span class="token attr-value"><span class="token punctuation">=</span><span class="token punctuation">"</span>(^answer/.*)<span class="token punctuation">"</span></span> <span class="token punctuation">/&gt;</span></span>
          <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>conditions</span> <span class="token attr-name">logicalGrouping</span><span class="token attr-value"><span class="token punctuation">=</span><span class="token punctuation">"</span>MatchAll<span class="token punctuation">"</span></span><span class="token punctuation">&gt;</span></span>
            <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>add</span> <span class="token attr-name">input</span><span class="token attr-value"><span class="token punctuation">=</span><span class="token punctuation">"</span>{REQUEST_FILENAME}<span class="token punctuation">"</span></span> <span class="token attr-name">matchType</span><span class="token attr-value"><span class="token punctuation">=</span><span class="token punctuation">"</span>IsFile<span class="token punctuation">"</span></span> <span class="token attr-name">negate</span><span class="token attr-value"><span class="token punctuation">=</span><span class="token punctuation">"</span>true<span class="token punctuation">"</span></span> <span class="token punctuation">/&gt;</span></span>
            <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>add</span> <span class="token attr-name">input</span><span class="token attr-value"><span class="token punctuation">=</span><span class="token punctuation">"</span>{REQUEST_FILENAME}<span class="token punctuation">"</span></span> <span class="token attr-name">matchType</span><span class="token attr-value"><span class="token punctuation">=</span><span class="token punctuation">"</span>IsDirectory<span class="token punctuation">"</span></span> <span class="token attr-name">negate</span><span class="token attr-value"><span class="token punctuation">=</span><span class="token punctuation">"</span>true<span class="token punctuation">"</span></span> <span class="token punctuation">/&gt;</span></span>
          <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>conditions</span><span class="token punctuation">&gt;</span></span>
          <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>action</span> <span class="token attr-name">type</span><span class="token attr-value"><span class="token punctuation">=</span><span class="token punctuation">"</span>Rewrite<span class="token punctuation">"</span></span> <span class="token attr-name">url</span><span class="token attr-value"><span class="token punctuation">=</span><span class="token punctuation">"</span>/answer/index.html<span class="token punctuation">"</span></span> <span class="token punctuation">/&gt;</span></span>
        <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>rule</span><span class="token punctuation">&gt;</span></span>
      <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>rules</span><span class="token punctuation">&gt;</span></span>
    <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>rewrite</span><span class="token punctuation">&gt;</span></span>
  <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>system.webServer</span><span class="token punctuation">&gt;</span></span>
<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>configuration</span><span class="token punctuation">&gt;</span></span>
</code></pre>

