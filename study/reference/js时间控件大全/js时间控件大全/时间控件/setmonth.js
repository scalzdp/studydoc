<!--
document.writeln('<div id=meizzDateLayer style="position: absolute; width: 122; height: 100px; z-index: 9998; display:none">');
document.writeln('<span id=tmpSelectYearLayer style="z-index:9999; position:absolute; top:2; left:18; display: none">');
document.writeln('</span>');
document.writeln('<table border=0 cellspacing=1 cellpadding=0 width=120 height=100 bgcolor=#000000 onselectstart="return false"> ');
document.writeln('<tr><td width=120 height=17 bgcolor=#FFFFFF> ');
document.writeln('<table border=0 cellspacing=1 cellpadding=0 width=120 height=15> ');
document.writeln('<tr align=center><td Author=meizz align=left> ');
document.writeln(' <input Author=meizz type=button value="<<" title="前一年" onclick="meizzPrevY()"  onfocus="this.blur()"  ');
document.writeln('style="cursor:hand; BACKGROUND-COLOR:#808080; BORDER-BOTTOM:#808080 1px outset; BORDER-LEFT:#808080 1px  ');
document.writeln('outset; BORDER-RIGHT:#808080 1px outset; BORDER-TOP:#808080 1px outset; FONT-SIZE:12px; height:15px; ');
document.writeln(' color: #FFD700; font-weight: bold"></td> ');
document.writeln(' <td width=70 align=center style="font-size:12px;cursor:default" Author=meizz> ');
document.writeln(' <span Author=meizz id=meizzYearHead onmouseover="style.backgroundColor=\'yellow\'"  ');
document.writeln(' onmouseout="style.backgroundColor=\'white\' " title="点击这里选择年份"  ');
document.writeln(' onclick="tmpSelectYearInnerHTML(this.innerText)" style="cursor: hand;"></span>&nbsp; 年</td> ');
document.writeln(' <td Author=meizz align=right><input name="button" type=button style="cursor:hand; BACKGROUND-COLOR:#808080;  ');
document.writeln('BORDER-BOTTOM:#808080 1px outset; BORDER-LEFT:#808080 1px outset; BORDER-RIGHT:#808080 1px outset;  ');
document.writeln(' BORDER-TOP:#808080 1px outset; font-size:12px; height:15px; color:#FFD700; font-weight:bold" title="后一年"  ');
document.writeln(' onfocus="this.blur()" onclick="meizzNextY()" value=" >>"  author=meizz /></td> ');
document.writeln(' </tr></table></td></tr> ');
document.writeln('<tr><td width=120 height=60> ');
document.writeln('<table border=0 cellspacing=1 cellpadding=0 width=120 height=60 bgcolor=#FFFFFF> ');
var n=0; for (j=0;j<2;j++){ document.writeln (' <tr align=center>'); for (i=0;i<6;i++){
document.writeln('<td width=10 height=10 id=meizzMonth'+n+' style="font-size:12px" Author=meizz onclick=meizzMonthClick(this.innerText)></td>');n++;}
document.writeln('</tr>');}
document.writeln('<tr align=center><td width=10 height=10 style="font-size:12px" id=meizzMonth12 Author=meizz  ></td> ');
document.writeln(' <td width=10 height=10 style="font-size:12px" id=meizzMonth12 Author=meizz ');
document.writeln('onclick=meizzMonthClick(this.innerText)></td> ');
document.writeln('<td colspan=5 align=right Author=meizz><span onclick=closeLayer() style="font-size:12px;cursor: hand" ');
document.writeln('Author=meizz title="返回（不选择）"><u>关闭</u></span>&nbsp;</td> ');
document.writeln(' </tr> ');
document.writeln(' </table></td></tr> ');
document.writeln(' <tr><td> ');
document.writeln(' <table border=0 cellspacing=1 cellpadding=0 width=100% bgcolor=#FFFFFF> ');
document.writeln(' <tr><td Author=meizz align=left><input Author=meizz type=button value="<<" title="前一年"  ');
document.writeln('onclick="meizzPrevY()"  onfocus="this.blur()" style="	cursor: hand;BACKGROUND-COLOR: ');
document.writeln('#808080;BORDER-BOTTOM: #808080 1px outset; BORDER-LEFT: #808080 1px outset; BORDER-RIGHT: #808080 1px ');
document.writeln('outset; BORDER-TOP: #808080 1px outset; FONT-SIZE: 12px; height: 20px;color: #FFD700; font-weight: ');
document.writeln('bold"></td> ');
document.writeln('<td  Author=meizz align=center><input Author=meizz type=button value="重置" onclick="meizzToMonth()" ');
document.writeln('onfocus="this.blur()" title="显示当前年月" style="cursor: hand;BACKGROUND-COLOR: ');
document.writeln('#808080;BORDER-BOTTOM: #808080 1px outset; BORDER-LEFT: #808080 1px outset; BORDER-RIGHT: #808080 ');
document.writeln('1px outset; BORDER-TOP: #808080 1px outset;font-size: 12px; height: 20px;color: #FFFFFF; ');
document.writeln(' font-weight: bold"></td> ');
document.writeln('<td   Author=meizz align=right><input name="button" type=button style="cursor: hand;BACKGROUND-COLOR: ');
document.writeln('#808080;BORDER-BOTTOM: #808080 1px outset; BORDER-LEFT: #808080 1px outset; BORDER-RIGHT: #808080 1px ');
document.writeln('outset; BORDER-TOP: #808080 1px outset;font-size: 12px; height: 20px;color: #FFD700; font-weight: ');
document.writeln('bold" title="后一年"  onfocus="this.blur()" onclick="meizzNextY()" value=" >>"  author=meizz /></td> ');
document.writeln(' </tr> ');
document.writeln(' </table> ');
document.writeln(' </td></tr> ');
document.writeln('</table></div> ');
 var outObject;
function setMonth(tt,obj) //主调函数
{
  if (arguments.length >  2){alert("对不起！传入本控件的参数太多！");return;}
  if (arguments.length == 0){alert("对不起！您没有传回本控件任何参数！");return;}
  var dads  = document.all.meizzDateLayer.style;
  var th = tt;
  var ttop  = tt.offsetTop;     //TT控件的定位点高
  var thei  = tt.clientHeight;  //TT控件本身的高
  var tleft = tt.offsetLeft;    //TT控件的定位点宽
  var ttyp  = tt.type;          //TT控件的类型
  while (tt = tt.offsetParent){ttop+=tt.offsetTop; tleft+=tt.offsetLeft;}
  dads.top  = (ttyp=="image")? ttop+thei : ttop+thei+6;
  dads.left = tleft;
  outObject = (arguments.length == 1) ? th : obj;
  dads.display = '';
  event.returnValue=false;
}



var yearChu=new Date().getFullYear(); //定义年的变量的初始值
var xieMonthChu=new Array(12);               //定义写日期的数组

function document.onclick()  //任意点击时关闭该控件
{ 
  with(window.event.srcElement)
  { if (tagName != "INPUT" && getAttribute("Author")==null)
    document.all.meizzDateLayer.style.display="none";
  }
}

function meizzWriteHead(yy)  //往 head 中写入当前的年与月
  { document.all.meizzYearHead.innerText  = yy;
    
  }

function tmpSelectYearInnerHTML(strYear) //年份的下拉框
{
  if (strYear.match(/\D/)!=null){alert("年份输入参数不是数字！");return;}
  var m = (strYear) ? strYear : new Date().getFullYear();
  if (m < 1000 || m > 9999) {alert("年份值不在 1000 到 9999 之间！");return;}
  var n = m - 10;
  if (n < 1000) n = 1000;
  if (n + 26 > 9999) n = 9974;
  var s = "<select Author=meizz name=tmpSelectYear style='font-size: 12px' "
     s += "onblur='document.all.tmpSelectYearLayer.style.display=\"none\"' "
     s += "onchange='document.all.tmpSelectYearLayer.style.display=\"none\";"
     s += "yearChu = this.value; meizzSetMonth(yearChu)'>\r\n";
  var selectInnerHTML = s;
  for (var i = n; i < n + 26; i++)
  {
    if (i == m)
       {selectInnerHTML += "<option value='" + i + "' selected>" + i + "年" + "</option>\r\n";}
    else {selectInnerHTML += "<option value='" + i + "'>" + i + "年" + "</option>\r\n";}
  }
  selectInnerHTML += "</select>";
  document.all.tmpSelectYearLayer.style.display="";
  document.all.tmpSelectYearLayer.innerHTML = selectInnerHTML;
  document.all.tmpSelectYear.focus();
}



function closeLayer()               //这个层的关闭
  {
    document.all.meizzDateLayer.style.display="none";
  }

function document.onkeydown()
  {
    if (window.event.keyCode==27)document.all.meizzDateLayer.style.display="none";
  }


function meizzPrevY()  //往前翻 Year
  {
    if(yearChu > 999 && yearChu <10000){yearChu--;}
    else{alert("年份超出范围（1000-9999）！");}
    meizzSetMonth(yearChu);
  }
function meizzNextY()  //往后翻 Year
  {
    if(yearChu > 999 && yearChu <10000){yearChu++;}
    else{alert("年份超出范围（1000-9999）！");}
    meizzSetMonth(yearChu);
  }
function meizzToMonth()  //ToMonth Button
  {
    yearChu = new Date().getFullYear();
   meizzSetMonth(yearChu);
  }

function meizzSetMonth(yy)   //主要的写程序**********
{
  meizzWriteHead(yy);
  
  for (var i = 0; i < 12; i++){xieMonthChu[i]=i+1;}  //将显示框的内容全部清空
 
  for (var i = 0; i < 12; i++)
  { var da = eval("document.all.meizzMonth"+i)     //书写新的一个月的日期星期排列
   if (xieMonthChu[i]!="")
      { da.innerHTML = "<b>" + xieMonthChu[i] + "</b>";
        da.style.backgroundColor = (yy == new Date().getFullYear()&&xieMonthChu[i]==new Date().getMonth()+1
        ) ? "#FFD700" : "#73a6de";
        da.style.cursor="hand";
      }
     else{da.innerHTML="";da.style.backgroundColor="";da.style.cursor="default";}
  }
}
function meizzMonthClick(n)  //点击显示框选取日期，主输入函数*************
{
  var yy = yearChu;
  
  if (outObject)
  {
    if (!n) {outObject.value=""; return;}
   
    outObject.value= yy + "-" + n  ; //注：在这里你可以输出改成你想要的格式
    closeLayer(); 
  }
  else {closeLayer(); alert("您所要输出的控件对象并不存在！");}
}
meizzSetMonth(yearChu);
// -->
