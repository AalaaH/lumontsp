

&lt;style type="text/css"&gt;


.csharpcode, .csharpcode pre
{
> font-size: small;
> color: black;
> font-family: Consolas, "Courier New", Courier, Monospace;
> background-color: #ffffff;
> /**white-space: pre;**/
}

.csharpcode pre { margin: 0em; }

.csharpcode .rem { color: #008000; }

.csharpcode .kwrd { color: #0000ff; }

.csharpcode .str { color: #006080; }

.csharpcode .op { color: #0000c0; }

.csharpcode .preproc { color: #cc6633; }

.csharpcode .asp { background-color: #ffff00; }

.csharpcode .html { color: #800000; }

.csharpcode .attr { color: #ff0000; }

.csharpcode .alt
{
> background-color: #f4f4f4;
> width: 100%;
> margin: 0em;
}

.csharpcode .lnum { color: #606060; }


&lt;/style&gt;



## Travelling Salesman Problem (TSP) using network search heuristics ##
<p><i>Note: This is a work in progress by Lusana Ali and Simon K who hijacked my project (GET UR OWN ALGORITHM! DAM U). I will be on holiday until March 09. GA code will be added then. For comments, advice, suggestions etc etc please get to me on krone@thekrone.org. </i></p>
<p><i>Lusana is finishing her final two subjects in Mathematics and Computing with a major in Operations Reseach. She particularly likes learning about search heuristics.</i></p>
<ol>
<blockquote><li>Local Search</li>
<li>Simulated Annealing (SA) </li>
<li>Genetic Algorithm (GA)</li>
<li>Detecting Closed Loops</li>
<li>Detecting Zig Zag Paths</li>
</ol></blockquote>

<h1>Simulated Annealing (SA) </h1>
<p>(SA Overview)<br>
<blockquote>Simulated Annealing is a random search technique. It's name and concept is derived from the annealing process in metallurgy. </p>
<p>&quot;A technique involving heating and controlled cooling of a material to increase the size of its crystals and reduce their defects. The heat causes the atoms to become unstuck from their initial positions (a local minimum of the internal energy) and wander randomly through states of higher energy; the slow cooling gives them more chances of finding configurations with lower internal energy than the initial one&quot; -Wiki </p>
<p>Simulated Annealing was one of the first algorithms I wanted to explore in solving the TSP. For more information on the algorithm please refer to <a href='http://www.ipp.mpg.de/~rfs/comas/Helsinki/helsinki04/CompScience/csep/csep1.phy.ornl.gov/csep/mo/NODE27.html'>http://www.ipp.mpg.de/~rfs/comas/Helsinki/helsinki04/CompScience/csep/csep1.phy.ornl.gov/csep/mo/NODE27.html</a>. </p>
<p>Some code and results are below:-</p>
<h2>Some results</h2>
<h3>Result set 1 - 150 random cities (open network)</h3>
<p><img src='http://thekrone.org/lusana.portfolio/TSP/images/run2a.png'>
<img src='http://thekrone.org/lusana.portfolio/TSP/images/run2b.png'>
<br>
<br>
Unknown end tag for </p><br>
<br>
<br>
<p>(Red lines show arcs that intersect with other arcs meaning there are closed loops in the solution. For the solution to be optimal, no arcs should be red - although as a side note, the method that determines whether an arc intersects with others has not been thoroughly tested)</p>
<br>
<br>
<hr/><br>
<br>
<br>
<h3>Result set 2 - 100 random cities (open network)</h3>
<p><img src='http://thekrone.org/lusana.portfolio/TSP/images/run3a.png'>
<img src='http://thekrone.org/lusana.portfolio/TSP/images/run3b.png'></blockquote>

<br>
<br>
Unknown end tag for </p><br>
<br>
<br>
<p>Still lots of red interesecting arcs, but a clear decrease in objective function is shown in the Distance vs Iteration plot</p>
<br>
<br>
<hr/><br>
<br>
<br>
<br>
<br>
<br>
<br>
<h3>Result set 3 - 75 random cities (open network)</h3>
<p><img src='http://thekrone.org/lusana.portfolio/TSP/images/run4a.png'>
<blockquote><img src='http://thekrone.org/lusana.portfolio/TSP/images/run4b.png'></blockquote>

<br>
<br>
Unknown end tag for </p><br>
<br>
<br>
<br>
<br>
<br>
<br>
<div>
<blockquote><pre>
<span class="rem">/// &lt;summary&gt;<br>
<br>
Unknown end tag for </span><br>
<br>
<br>
<span class="rem">/// Solves using Simulated Annealing<br>
<br>
Unknown end tag for </span><br>
<br>
<br>
<span class="rem">/// &lt;/summary&gt;<br>
<br>
Unknown end tag for </span><br>
<br>
<br>
<span class="rem">/// &lt;param name="cities"&gt;list of cities&lt;/param&gt;<br>
<br>
Unknown end tag for </span><br>
<br>
<br>
<span class="rem">/// &lt;param name="temp"&gt;temperature&lt;/param&gt;<br>
<br>
Unknown end tag for </span><br>
<br>
<br>
<span class="rem">/// &lt;param name="delta"&gt;&lt;/param&gt;<br>
<br>
Unknown end tag for </span><br>
<br>
<br>
<span class="kwrd">public<br>
<br>
Unknown end tag for </span><br>
<br>
 <span class="kwrd">void<br>
<br>
Unknown end tag for </span><br>
<br>
 SimAnneal(<span class="kwrd">ref<br>
<br>
Unknown end tag for </span><br>
<br>
 List&lt;City&gt; cities, <span class="kwrd">double<br>
<br>
Unknown end tag for </span><br>
<br>
 temp, <span class="kwrd">double<br>
<br>
Unknown end tag for </span><br>
<br>
 delta)<br>
{<br>
<span class="kwrd">int<br>
<br>
Unknown end tag for </span><br>
<br>
 numCities = cities.Count;<br>
<br>
<span class="kwrd">int<br>
<br>
Unknown end tag for </span><br>
<br>
 MAX_ITER = 2000;<br>
<span class="kwrd">int<br>
<br>
Unknown end tag for </span><br>
<br>
 lBound = 3, uBound = numCities-1;<br>
<span class="kwrd">double<br>
<br>
Unknown end tag for </span><br>
<br>
 curD = 0;<br>
<br>
Random rd = <span class="kwrd">new<br>
<br>
Unknown end tag for </span><br>
<br>
 Random();<br>
<br>
<span class="kwrd">for<br>
<br>
Unknown end tag for </span><br>
<br>
 (<span class="kwrd">int<br>
<br>
Unknown end tag for </span><br>
<br>
 i = 0; i &lt; MAX_ITER; i++)<br>
{<br>
<span class="kwrd">int<br>
<br>
Unknown end tag for </span><br>
<br>
 r1 = 0, r2 = 0;<br>
<br>
<span class="rem">// change temperature<br>
<br>
Unknown end tag for </span><br>
<br>
<br>
temp -= delta;<br>
<br>
<span class="kwrd">for<br>
<br>
Unknown end tag for </span><br>
<br>
 (<span class="kwrd">int<br>
<br>
Unknown end tag for </span><br>
<br>
 c = 0; c &lt; cities.Count; c++)<br>
{<br>
<span class="rem">// find random c1 and c2 to swap within the bounds<br>
<br>
Unknown end tag for </span><br>
<br>
<br>
r1 = rd.Next(lBound, uBound-1);<br>
r2 = rd.Next(lBound, uBound-1);<br>
<br>
<span class="kwrd">while<br>
<br>
Unknown end tag for </span><br>
<br>
 (r1 == r2) r2 = rd.Next(lBound, uBound);<br>
<br>
<span class="rem">// step a - ensure r2 &gt; r1<br>
<br>
Unknown end tag for </span><br>
<br>
<br>
<span class="kwrd">if<br>
<br>
Unknown end tag for </span><br>
<br>
 (r2 &lt; r1)<br>
{<br>
<span class="kwrd">int<br>
<br>
Unknown end tag for </span><br>
<br>
 tempR = r1;<br>
r1 = r2;<br>
r2 = tempR;<br>
}<br>
<br>
<span class="rem">// step b<br>
<br>
Unknown end tag for </span><br>
<br>
<br>
<span class="rem">// curD = distance frm prev node for both r1's<br>
<br>
Unknown end tag for </span><br>
<br>
<br>
curD = MathHelper.getDistance(cities[r1 - 1], cities[r1]) + MathHelper.getDistance(cities[r2 + 1], cities[r2]);<br>
<span class="kwrd">double<br>
<br>
Unknown end tag for </span><br>
<br>
 newD = MathHelper.getDistance(cities[r1], cities[r2 + 1]) + MathHelper.getDistance(cities[r1-1], cities[r2]);<br>
<span class="kwrd">bool<br>
<br>
Unknown end tag for </span><br>
<br>
 accept = <span class="kwrd">false<br>
<br>
Unknown end tag for </span><br>
<br>
;<br>
<br>
<span class="kwrd">if<br>
<br>
Unknown end tag for </span><br>
<br>
 (newD &lt; curD) accept = <span class="kwrd">true<br>
<br>
Unknown end tag for </span><br>
<br>
; <span class="rem">// if new solution better accept<br>
<br>
Unknown end tag for </span><br>
<br>
<br>
<span class="kwrd">if<br>
<br>
Unknown end tag for </span><br>
<br>
 (temp &gt; 0.01) <span class="kwrd">if<br>
<br>
Unknown end tag for </span><br>
<br>
 (Accept(newD, curD, temp)) accept = <span class="kwrd">true<br>
<br>
Unknown end tag for </span><br>
<br>
;<br>
<br>
<span class="kwrd">if<br>
<br>
Unknown end tag for </span><br>
<br>
 (accept)<br>
{<br>
<span class="kwrd">int<br>
<br>
Unknown end tag for </span><br>
<br>
 max = Convert.ToInt32(Math.Round((<span class="kwrd">double<br>
<br>
Unknown end tag for </span><br>
<br>
)((r2 - r1) / 2)));<br>
<span class="kwrd">for<br>
<br>
Unknown end tag for </span><br>
<br>
 (<span class="kwrd">int<br>
<br>
Unknown end tag for </span><br>
<br>
 s = 0; s &lt;max; s++)<br>
{<br>
City tempC = cities[r1 + s];<br>
cities[r1 + s] = cities[r2 - s];<br>
cities[r2 - s] = tempC;<br>
}<br>
}<br>
}<br>
Report(cities, curD); <span class="rem">// report solution to delegate<br>
<br>
Unknown end tag for </span><br>
<br>
<br>
}<br>
<br>
<span class="rem">// check for closed loops<br>
<br>
Unknown end tag for </span><br>
<br>
<br>
<span class="kwrd">int<br>
<br>
Unknown end tag for </span><br>
<br>
 k = 0;<br>
<span class="kwrd">while<br>
<br>
Unknown end tag for </span><br>
<br>
 (k &lt; cities.Count - 1)<br>
{<br>
Collides(k, cities);<br>
k++;<br>
}<br>
}</pre></blockquote>

</div>


<p>&nbsp;</p>
<h2>Accepting an increase in the solution.</h2>
The major  benefit of SImulated annealing is that it allows you to take &quot;jumps&quot; from a local minima to a potentially better local minima (which may be the global minima). The algorithm naturally accepts decreases in the objective function, and accepts increases in the objective function with a probability of Exp(-df/T)<br>
<br>
Unknown end tag for </p><br>
<br>
<br>
<div>

<pre>
<span class="rem">/// &lt;summary&gt;<br>
<br>
Unknown end tag for </span><br>
<br>
<br>
<span class="rem">/// whether to accept the increase in SimAnneal or not<br>
<br>
Unknown end tag for </span><br>
<br>
<br>
<span class="rem">/// &lt;/summary&gt;<br>
<br>
Unknown end tag for </span><br>
<br>
<br>
<span class="rem">/// &lt;param name="distNew"&gt;the new distance&lt;/param&gt;<br>
<br>
Unknown end tag for </span><br>
<br>
<br>
<span class="rem">/// &lt;param name="distOld"&gt;the old distance before this iteration&lt;/param&gt;<br>
<br>
Unknown end tag for </span><br>
<br>
<br>
<span class="rem">/// &lt;param name="temp"&gt;current temperature&lt;/param&gt;<br>
<br>
Unknown end tag for </span><br>
<br>
<br>
<span class="rem">/// &lt;returns&gt;boolean to accept or not&lt;/returns&gt;<br>
<br>
Unknown end tag for </span><br>
<br>
<br>
<span class="kwrd">private<br>
<br>
Unknown end tag for </span><br>
<br>
 <span class="kwrd">bool<br>
<br>
Unknown end tag for </span><br>
<br>
 Accept(<span class="kwrd">double<br>
<br>
Unknown end tag for </span><br>
<br>
 distNew, <span class="kwrd">double<br>
<br>
Unknown end tag for </span><br>
<br>
 distOld, <span class="kwrd">double<br>
<br>
Unknown end tag for </span><br>
<br>
 temp)<br>
{<br>
<span class="kwrd">double<br>
<br>
Unknown end tag for </span><br>
<br>
 prob = <span class="kwrd">new<br>
<br>
Unknown end tag for </span><br>
<br>
 Random().NextDouble();<br>
<span class="kwrd">double<br>
<br>
Unknown end tag for </span><br>
<br>
 sim = Math.Exp(-5 * (distNew - distOld) / temp);<br>
<span class="kwrd">if<br>
<br>
Unknown end tag for </span><br>
<br>
 (prob &lt; sim) <span class="kwrd">return<br>
<br>
Unknown end tag for </span><br>
<br>
 <span class="kwrd">true<br>
<br>
Unknown end tag for </span><br>
<br>
;<br>
<br>
<span class="kwrd">return<br>
<br>
Unknown end tag for </span><br>
<br>
 <span class="kwrd">false<br>
<br>
Unknown end tag for </span><br>
<br>
;<br>
}</pre>

</div>



<h2>Detecting Closed Loops</h2>
<blockquote>An optimal solution can not have any closed loops. This means that no arcs must cross paths (the salesman must not ever travel to a point he/she has been to before). In order to meet this requirement, I created a function that is to be executed at the finding any good solutions in order to optimise it further. This was through detecting whether any arcs indeed intersected. The main ideas and deciding factors are below:<br>
<br>
Unknown end tag for </p><br>
<br>
<br>
<ol>
<li> The current arc does not intersect with another arc, if that arc resides both its points exclusively in a region outside the bounds of the original arc (as shown below)</li>
<li>Arc does not intersect if the intersection of the two arcs has an x &lt;= original_arc.x1 or x&gt;= original_arc.x2 where x1 &lt; x2 (see code below further below)</li>
</ol>
<p><img src='http://thekrone.org/lusana.portfolio/TSP/images/collides.png'>

Unknown end tag for </p>

<br>
<p><img src='http://thekrone.org/lusana.portfolio/TSP/images/collides2.png'>

Unknown end tag for </p>

<br>
<p>Lightly coloured arcs can never intersect with arc1 (original arc) because they reside exclusively in a region that is outside the bounds of arc1. E.g. The arc shown in region 3, both its points reside in x3. x3 &gt; arc.x2</p>
<p>&nbsp;</p></blockquote>

<div>

<pre>
<span class="kwrd">public<br>
<br>
Unknown end tag for </span><br>
<br>
 <span class="kwrd">bool<br>
<br>
Unknown end tag for </span><br>
<br>
 Collides(<span class="kwrd">int<br>
<br>
Unknown end tag for </span><br>
<br>
 cur, List&lt;City&gt; cities)<br>
{<br>
List&lt;Arc&gt; arcs = <span class="kwrd">new<br>
<br>
Unknown end tag for </span><br>
<br>
 List&lt;Arc&gt;();<br>
<span class="kwrd">for<br>
<br>
Unknown end tag for </span><br>
<br>
 (<span class="kwrd">int<br>
<br>
Unknown end tag for </span><br>
<br>
 i = 0; i &lt; cities.Count - 1; i++)<br>
{<br>
arcs.Add(<span class="kwrd">new<br>
<br>
Unknown end tag for </span><br>
<br>
 Arc(cities[i], cities[i + 1]));<br>
}<br>
<br>
<br>
arcs[cur].Collides = <span class="kwrd">false<br>
<br>
Unknown end tag for </span><br>
<br>
;<br>
arcs[cur].FrmCity.Collides = <span class="kwrd">false<br>
<br>
Unknown end tag for </span><br>
<br>
;<br>
<br>
<span class="kwrd">for<br>
<br>
Unknown end tag for </span><br>
<br>
 (<span class="kwrd">int<br>
<br>
Unknown end tag for </span><br>
<br>
 x = 0; x &lt; arcs.Count; x++)<br>
{<br>
<span class="kwrd">if<br>
<br>
Unknown end tag for </span><br>
<br>
 (cur == x) { x++; <span class="kwrd">continue<br>
<br>
Unknown end tag for </span><br>
<br>
; }<br>
<span class="kwrd">if<br>
<br>
Unknown end tag for </span><br>
<br>
 (arcs[x].inRegionX(0, arcs[cur].MinX)) <span class="kwrd">continue<br>
<br>
Unknown end tag for </span><br>
<br>
; <span class="rem">// reg x1<br>
<br>
Unknown end tag for </span><br>
<br>
<br>
<span class="kwrd">if<br>
<br>
Unknown end tag for </span><br>
<br>
 (arcs[x].inRegionX(arcs[cur].MaxX, Int32.MaxValue)) <span class="kwrd">continue<br>
<br>
Unknown end tag for </span><br>
<br>
; <span class="rem">// reg x3<br>
<br>
Unknown end tag for </span><br>
<br>
<br>
<span class="kwrd">if<br>
<br>
Unknown end tag for </span><br>
<br>
 (arcs[x].inRegionY(0, arcs[cur].MinY)) <span class="kwrd">continue<br>
<br>
Unknown end tag for </span><br>
<br>
; <span class="rem">// reg y1<br>
<br>
Unknown end tag for </span><br>
<br>
<br>
<span class="kwrd">if<br>
<br>
Unknown end tag for </span><br>
<br>
 (arcs[x].inRegionY(arcs[cur].MaxY, Int32.MaxValue)) <span class="kwrd">continue<br>
<br>
Unknown end tag for </span><br>
<br>
;  <span class="rem">// reg y3<br>
<br>
Unknown end tag for </span><br>
<br>
<br>
<br>
Point pt = MathHelper.getIntercept(arcs[cur], arcs[x]);<br>
<br>
<span class="kwrd">if<br>
<br>
Unknown end tag for </span><br>
<br>
 (pt.X &lt;= arcs[cur].MinX || pt.X &gt;= arcs[cur].MaxX) <span class="kwrd">continue<br>
<br>
Unknown end tag for </span><br>
<br>
;<br>
<br>
arcs[cur].Collides = <span class="kwrd">true<br>
<br>
Unknown end tag for </span><br>
<br>
;<br>
arcs[cur].FrmCity.Collides = <span class="kwrd">true<br>
<br>
Unknown end tag for </span><br>
<br>
;<br>
<span class="kwrd">return<br>
<br>
Unknown end tag for </span><br>
<br>
 <span class="kwrd">true<br>
<br>
Unknown end tag for </span><br>
<br>
;<br>
<br>
}<br>
<br>
<span class="kwrd">return<br>
<br>
Unknown end tag for </span><br>
<br>
 arcs[cur].Collides;<br>
}</pre>
</div>
<br>
<br>
Unknown end tag for </body><br>
<br>
<br>
<br>
<br>
Unknown end tag for </html><br>
<br>
