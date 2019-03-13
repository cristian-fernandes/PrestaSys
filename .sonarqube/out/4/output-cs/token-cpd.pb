�%
QC:\projects\personal\prestasys\Unisul.PrestaSys.Web\Controllers\BaseController.cs
	namespace

 	
Unisul


 
.

 
	PrestaSys

 
.

 
Web

 
.

 
Controllers

 *
{ 
public 

class 
BaseController 
:  !

Controller" ,
{ 
private 
readonly 
IUsuarioService (
_service) 1
;1 2
public 
BaseController 
( 
IUsuarioService -
service. 5
)5 6
{ 	
_service 
= 
service 
; 
} 	
public 
override 
void 
OnActionExecuted -
(- .!
ActionExecutedContext. C
filterContextD Q
)Q R
{ 	
if 
( 
User 
. 
Identity 
. 
IsAuthenticated -
&&. 0
ViewData1 9
.9 :
Model: ?
is@ B
BaseViewModelC P
modelQ V
)V W
{ 
var 
usuario 
= 
GetLoggedUser +
(+ ,
), -
;- .
model 
. 
UsuarioLogado #
=$ %
new& )

DadosLogin* 4
{ 
Nome 
= 
usuario "
." #
Nome# '
,' (
	Sobrenome 
= 
usuario  '
.' (
	Sobrenome( 1
,1 2
Email 
= 
usuario #
.# $
Email$ )
,) *
FlagGerente   
=    !
usuario  " )
.  ) *
FlagGerente  * 5
,  5 6!
FlagGerenteFinanceiro!! )
=!!* +
usuario!!, 3
.!!3 4!
FlagGerenteFinanceiro!!4 I
}"" 
;"" 
}## 
base%% 
.%% 
OnActionExecuted%% !
(%%! "
filterContext%%" /
)%%/ 0
;%%0 1
}&& 	
public(( 
override(( 
void(( 
OnActionExecuting(( .
(((. /"
ActionExecutingContext((/ E
filterContext((F S
)((S T
{)) 	
try** 
{++ 
if,, 
(,, 
User,, 
.,, 
Identity,, !
.,,! "
IsAuthenticated,," 1
),,1 2
return-- 
;-- 
if// 
(// 
filterContext// !
.//! "
	RouteData//" +
.//+ ,
Values//, 2
[//2 3
$str//3 ?
]//? @
.//@ A
ToString//A I
(//I J
)//J K
==//L N
$str//O V
)//V W
return00 
;00 
filterContext22 
.22 
Result22 $
=22% &
new22' *
RedirectResult22+ 9
(229 :
Url22: =
.22= >
Action22> D
(22D E
$str22E L
,22L M
$str22N U
)22U V
)22V W
;22W X
}33 
catch44 
(44 
	Exception44 
ex44 
)44  
{55 
Console66 
.66 
Write66 
(66 
ex66  
)66  !
;66! "
}77 
}88 	
	protected:: 
Usuario:: 
GetLoggedUser:: '
(::' (
)::( )
{;; 	
var<< 
usuarioLogado<< 
=<< 
_service<<  (
.<<( )
GetUsuarioByEmail<<) :
(<<: ;
GetClaimValueByType<<; N
(<<N O

ClaimTypes<<O Y
.<<Y Z
Email<<Z _
)<<_ `
)<<` a
;<<a b
if>> 
(>> 
usuarioLogado>> 
!=>>  
null>>! %
)>>% &
return?? 
usuarioLogado?? $
;??$ %
RedirectToActionAA 
(AA 
$strAA $
,AA$ %
$strAA& ,
)AA, -
;AA- .
returnBB 
nullBB 
;BB 
}CC 	
privateEE 
stringEE 
GetClaimValueByTypeEE *
(EE* +
stringEE+ 1
typeEE2 6
)EE6 7
{FF 	
returnGG 
RequestGG 
.GG 
HttpContextGG &
.GG& '
UserGG' +
.GG+ ,
ClaimsGG, 2
.GG2 3
FirstGG3 8
(GG8 9
tGG9 :
=>GG; =
tGG> ?
.GG? @
TypeGG@ D
==GGE G
typeGGH L
)GGL M
.GGM N
ValueGGN S
;GGS T
}HH 	
}II 
}JJ �
QC:\projects\personal\prestasys\Unisul.PrestaSys.Web\Controllers\HomeController.cs
	namespace 	
Unisul
 
. 
	PrestaSys 
. 
Web 
. 
Controllers *
{ 
public 

class 
HomeController 
:  !
BaseController" 0
{		 
private

 
readonly

 
IUsuarioService

 (
_usuarioService

) 8
;

8 9
public 
HomeController 
( 
IUsuarioService -
usuarioService. <
)< =
:> ?
base@ D
(D E
usuarioServiceE S
)S T
{ 	
_usuarioService 
= 
usuarioService ,
;, -
} 	
[ 	
ResponseCache	 
( 
Duration 
=  !
$num" #
,# $
Location% -
=. /!
ResponseCacheLocation0 E
.E F
NoneF J
,J K
NoStoreL S
=T U
trueV Z
)Z [
][ \
public 
IActionResult 
Error "
(" #
)# $
{ 	
return 
View 
( 
new 
ErrorViewModel *
{ 
	RequestId 
= 
Activity $
.$ %
Current% ,
?, -
.- .
Id. 0
??1 3
HttpContext4 ?
.? @
TraceIdentifier@ O
} 
) 
; 
} 	
public 
IActionResult 
Index "
(" #
)# $
{ 	
return 
View 
( 
) 
; 
} 	
} 
} �0
RC:\projects\personal\prestasys\Unisul.PrestaSys.Web\Controllers\LoginController.cs
	namespace 	
Unisul
 
. 
	PrestaSys 
. 
Web 
. 
Controllers *
{ 
public 

class 
LoginController  
:! "
BaseController# 1
{ 
private 
readonly 
IUsuarioService (
_usuarioService) 8
;8 9
public 
LoginController 
( 
IUsuarioService .
usuarioService/ =
)= >
:? @
baseA E
(E F
usuarioServiceF T
)T U
{ 	
_usuarioService 
= 
usuarioService ,
;, -
} 	
public 
IActionResult 
About "
(" #
)# $
{ 	
return 
View 
( 
new 
LoginViewModel *
(* +
)+ ,
), -
;- .
} 	
public 
IActionResult 
Index "
(" #
)# $
{ 	
return 
View 
( 
) 
; 
} 	
public   
IActionResult   
Login   "
(  " #
string  # )
email  * /
,  / 0
string  1 7
senha  8 =
)  = >
{!! 	
try"" 
{## 
if$$ 
($$ 

ModelState$$ 
.$$ 
IsValid$$ &
)$$& '
{%% 
var&& 
usuario&& 
=&&  !
_usuarioService&&" 1
.&&1 2%
GetUsuarioByEmailAndSenha&&2 K
(&&K L
email&&L Q
,&&Q R
senha&&S X
)&&X Y
;&&Y Z
if(( 
((( 
usuario(( 
!=((  "
null((# '
)((' (
{)) 
LogarUsuario** $
(**$ %
usuario**% ,
,**, -
false**. 3
)**3 4
;**4 5
return,, 
RedirectToAction,, /
(,,/ 0
$str,,0 7
,,,7 8
$str,,9 E
),,E F
;,,F G
}-- 

ModelState// 
.// 
AddModelError// ,
(//, -
string//- 3
.//3 4
Empty//4 9
,//9 :
$str//; s
)//s t
;//t u
}00 
}11 
catch22 
(22 
	Exception22 
ex22 
)22  
{33 
Console44 
.44 
Write44 
(44 
ex44  
)44  !
;44! "
}55 
return77 
View77 
(77 
$str77 
)77  
;77  !
}88 	
public:: 
IActionResult:: 
Logoff:: #
(::# $
)::$ %
{;; 	
try<< 
{== 
var>> !
authenticationManager>> )
=>>* +
Request>>, 3
.>>3 4
HttpContext>>4 ?
;>>? @!
authenticationManager@@ %
.@@% &
SignOutAsync@@& 2
(@@2 3(
CookieAuthenticationDefaults@@3 O
.@@O P 
AuthenticationScheme@@P d
)@@d e
;@@e f
}AA 
catchBB 
(BB 
	ExceptionBB 
exBB 
)BB  
{CC 
throwDD 
exDD 
;DD 
}EE 
returnGG 
ViewGG 
(GG 
$strGG 
)GG  
;GG  !
}HH 	
publicJJ 
IActionResultJJ 
PrivacyJJ $
(JJ$ %
)JJ% &
{KK 	
returnLL 
ViewLL 
(LL 
newLL 
LoginViewModelLL *
(LL* +
)LL+ ,
)LL, -
;LL- .
}MM 	
privateOO 
voidOO 
LogarUsuarioOO !
(OO! "
UsuarioOO" )
loginUsuarioOO* 6
,OO6 7
boolOO8 <
isPersistentOO= I
)OOI J
{PP 	
varQQ 
claimsQQ 
=QQ 
newQQ 
ListQQ !
<QQ! "
ClaimQQ" '
>QQ' (
(QQ( )
)QQ) *
;QQ* +
trySS 
{TT 
claimsUU 
.UU 
AddUU 
(UU 
newUU 
ClaimUU $
(UU$ %

ClaimTypesUU% /
.UU/ 0
EmailUU0 5
,UU5 6
loginUsuarioUU7 C
.UUC D
EmailUUD I
)UUI J
)UUJ K
;UUK L
claimsVV 
.VV 
AddVV 
(VV 
newVV 
ClaimVV $
(VV$ %

ClaimTypesVV% /
.VV/ 0
NameVV0 4
,VV4 5
loginUsuarioVV6 B
.VVB C
NomeVVC G
)VVG H
)VVH I
;VVI J
varWW 
claimIdentiesWW !
=WW" #
newWW$ '
ClaimsIdentityWW( 6
(WW6 7
claimsWW7 =
,WW= >(
CookieAuthenticationDefaultsWW? [
.WW[ \ 
AuthenticationSchemeWW\ p
)WWp q
;WWq r
varXX 
claimPrincipalXX "
=XX# $
newXX% (
ClaimsPrincipalXX) 8
(XX8 9
claimIdentiesXX9 F
)XXF G
;XXG H
varYY !
authenticationManagerYY )
=YY* +
RequestYY, 3
.YY3 4
HttpContextYY4 ?
;YY? @!
authenticationManager[[ %
.[[% &
SignInAsync[[& 1
([[1 2(
CookieAuthenticationDefaults[[2 N
.[[N O 
AuthenticationScheme[[O c
,[[c d
claimPrincipal\\ "
,\\" #
new\\$ '$
AuthenticationProperties\\( @
{\\A B
IsPersistent\\B N
=\\O P
isPersistent\\Q ]
}\\] ^
)\\^ _
;\\_ `
}]] 
catch^^ 
(^^ 
	Exception^^ 
ex^^ 
)^^  
{__ 
throw`` 
ex`` 
;`` 
}aa 
}bb 	
}cc 
}dd Ǻ
WC:\projects\personal\prestasys\Unisul.PrestaSys.Web\Controllers\PrestacoesController.cs
	namespace 	
Unisul
 
. 
	PrestaSys 
. 
Web 
. 
Controllers *
{ 
public 

class  
PrestacoesController %
:& '
BaseController( 6
{ 
private 
readonly 
JsReportSettings )
_jsReportSettings* ;
;; <
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
IPrestacaoService *
_prestacaoService+ <
;< =
private 
readonly 
IUsuarioService (
_usuarioService) 8
;8 9
private 
readonly 
IViewRenderService +
_viewRenderService, >
;> ?
public!!  
PrestacoesController!! #
(!!# $
IUsuarioService!!$ 3
usuarioService!!4 B
,!!B C
IPrestacaoService!!D U
prestacaoService!!V f
,!!f g
IMapper!!h o
mapper!!p v
,!!v w
IOptions"" 
<"" 
JsReportSettings"" %
>""% &
jsReportSettings""' 7
,""7 8
IViewRenderService""9 K
viewRenderService""L ]
)""] ^
:## 
base## 
(## 
usuarioService## !
)##! "
{$$ 	
_usuarioService%% 
=%% 
usuarioService%% ,
;%%, -
_prestacaoService&& 
=&& 
prestacaoService&&  0
;&&0 1
_mapper'' 
='' 
mapper'' 
;'' 
_jsReportSettings(( 
=(( 
jsReportSettings((  0
.((0 1
Value((1 6
;((6 7
_viewRenderService)) 
=))  
viewRenderService))! 2
;))2 3
}** 	
public,, 
IActionResult,, 
Approve,, $
(,,$ %
int,,% (
?,,( )
id,,* ,
),,, -
{-- 	
if.. 
(.. 
id.. 
==.. 
null.. 
).. 
return// 
NotFound// 
(//  
)//  !
;//! "
var11 
	prestacao11 
=11 
_prestacaoService11 -
.11- .
GetById11. 5
(115 6
id116 8
.118 9
Value119 >
)11> ?
;11? @
if33 
(33 
	prestacao33 
==33 
null33 !
)33! "
return44 
NotFound44 
(44  
)44  !
;44! "
var66 
prestacaoViewModel66 "
=66# $
_mapper66% ,
.66, -
Map66- 0
<660 1
PrestacaoViewModel661 C
>66C D
(66D E
	prestacao66E N
)66N O
;66O P
if88 
(88 
	prestacao88 
.88 
ImagemComprovante88 +
!=88, .
null88/ 3
)883 4
prestacaoViewModel99 "
.99" # 
ImagemComprovanteSrc99# 7
=998 9
$str:: (
+::) *
Convert::+ 2
.::2 3
ToBase64String::3 A
(::A B
	prestacao::B K
.::K L
ImagemComprovante::L ]
)::] ^
;::^ _
return<< 
View<< 
(<< 
prestacaoViewModel<< *
)<<* +
;<<+ ,
}== 	
[@@ 	
HttpPost@@	 
]@@ 
[AA 	

ActionNameAA	 
(AA 
$strAA 
)AA 
]AA 
[BB 	$
ValidateAntiForgeryTokenBB	 !
]BB! "
publicCC 
IActionResultCC 
ApproveConfirmedCC -
(CC- .
intCC. 1
idCC2 4
,CC4 5
stringCC6 <"
justificativaAprovacaoCC= S
)CCS T
{DD 	
_prestacaoServiceEE 
.EE 
AprovarPrestacaoEE .
(EE. /
idEE/ 1
,EE1 2"
justificativaAprovacaoEE3 I
,EEI J
PrestacaoStatusEnumEEK ^
.EE^ _"
EmAprovacaoOperacionalEE_ u
)EEu v
;EEv w
returnFF 
RedirectToActionFF #
(FF# $
nameofFF$ *
(FF* +!
PrestacoesParaAprovarFF+ @
)FF@ A
)FFA B
;FFB C
}GG 	
publicII 
IActionResultII 
ApproveFinanceiroII .
(II. /
intII/ 2
?II2 3
idII4 6
)II6 7
{JJ 	
ifKK 
(KK 
idKK 
==KK 
nullKK 
)KK 
returnLL 
NotFoundLL 
(LL  
)LL  !
;LL! "
varNN 
	prestacaoNN 
=NN 
_prestacaoServiceNN -
.NN- .
GetByIdNN. 5
(NN5 6
idNN6 8
.NN8 9
ValueNN9 >
)NN> ?
;NN? @
ifPP 
(PP 
	prestacaoPP 
==PP 
nullPP !
)PP! "
returnQQ 
NotFoundQQ 
(QQ  
)QQ  !
;QQ! "
varSS 
prestacaoViewModelSS "
=SS# $
_mapperSS% ,
.SS, -
MapSS- 0
<SS0 1
PrestacaoViewModelSS1 C
>SSC D
(SSD E
	prestacaoSSE N
)SSN O
;SSO P
ifUU 
(UU 
	prestacaoUU 
.UU 
ImagemComprovanteUU +
!=UU, .
nullUU/ 3
)UU3 4
prestacaoViewModelVV "
.VV" # 
ImagemComprovanteSrcVV# 7
=VV8 9
$strWW (
+WW) *
ConvertWW+ 2
.WW2 3
ToBase64StringWW3 A
(WWA B
	prestacaoWWB K
.WWK L
ImagemComprovanteWWL ]
)WW] ^
;WW^ _
returnYY 
ViewYY 
(YY 
prestacaoViewModelYY *
)YY* +
;YY+ ,
}ZZ 	
[]] 	
HttpPost]]	 
]]] 
[^^ 	

ActionName^^	 
(^^ 
$str^^ '
)^^' (
]^^( )
[__ 	$
ValidateAntiForgeryToken__	 !
]__! "
public`` 
IActionResult`` &
ApproveFinanceiroConfirmed`` 7
(``7 8
int``8 ;
id``< >
,``> ?
string``@ F,
 justificativaAprovacaoFinanceira``G g
)``g h
{aa 	
_prestacaoServicebb 
.bb 
AprovarPrestacaobb .
(bb. /
idbb/ 1
,bb1 2,
 justificativaAprovacaoFinanceirabb3 S
,bbS T
PrestacaoStatusEnumcc #
.cc# $!
EmAprovacaoFinanceiracc$ 9
)cc9 :
;cc: ;
returndd 
RedirectToActiondd #
(dd# $
nameofdd$ *
(dd* ++
PrestacoesParaAprovarFinanceirodd+ J
)ddJ K
)ddK L
;ddL M
}ee 	
publichh 
IActionResulthh 
Createhh #
(hh# $
)hh$ %
{ii 	
varjj 
usuarioLogadojj 
=jj 
GetLoggedUserjj  -
(jj- .
)jj. /
;jj/ 0
varll 
prestacaoViewModelll "
=ll# $
newll% (
PrestacaoViewModelll) ;
{mm 
AprovadorIdnn 
=nn 
usuarioLogadonn +
.nn+ ,
	GerenteIdnn, 5
,nn5 6!
AprovadorFinanceiroIdoo %
=oo& '
usuarioLogadooo( 5
.oo5 6
GerenteFinanceiroIdoo6 I
,ooI J

EmitenteIdpp 
=pp 
usuarioLogadopp *
.pp* +
Idpp+ -
,pp- .
StatusIdqq 
=qq 
(qq 
intqq 
)qq  
PrestacaoStatusEnumqq! 4
.qq4 5"
EmAprovacaoOperacionalqq5 K
,qqK L#
TipoPrestacaoSelectListrr '
=rr( )&
GetAllPrestacoesSelectListrr* D
(rrD E
)rrE F
}ss 
;ss 
returnuu 
Viewuu 
(uu 
prestacaoViewModeluu *
)uu* +
;uu+ ,
}vv 	
[yy 	
HttpPostyy	 
]yy 
[zz 	$
ValidateAntiForgeryTokenzz	 !
]zz! "
public{{ 
IActionResult{{ 
Create{{ #
({{# $
PrestacaoViewModel{{$ 6
prestacaoViewModel{{7 I
){{I J
{|| 	
if}} 
(}} 

ModelState}} 
.}} 
IsValid}} "
)}}" #
{~~ 
var 
	prestacao 
= 
_mapper  '
.' (
Map( +
<+ ,
	Prestacao, 5
>5 6
(6 7
prestacaoViewModel7 I
)I J
;J K
	prestacao
�� 
.
�� 
ImagemComprovante
�� +
=
��, -
GetImageBytes
��. ;
(
��; < 
prestacaoViewModel
��< N
.
��N O
ImagemComprovante
��O `
)
��` a
;
��a b
_prestacaoService
�� !
.
��! "
Create
��" (
(
��( )
	prestacao
��) 2
)
��2 3
;
��3 4
return
�� 
RedirectToAction
�� '
(
��' (
nameof
��( .
(
��. /
Index
��/ 4
)
��4 5
)
��5 6
;
��6 7
}
�� 
var
�� 
usuarioLogado
�� 
=
�� 
GetLoggedUser
��  -
(
��- .
)
��. /
;
��/ 0 
prestacaoViewModel
�� 
.
�� 
AprovadorId
�� *
=
��+ ,
usuarioLogado
��- :
.
��: ;
	GerenteId
��; D
;
��D E 
prestacaoViewModel
�� 
.
�� #
AprovadorFinanceiroId
�� 4
=
��5 6
usuarioLogado
��7 D
.
��D E!
GerenteFinanceiroId
��E X
;
��X Y 
prestacaoViewModel
�� 
.
�� 

EmitenteId
�� )
=
��* +
usuarioLogado
��, 9
.
��9 :
Id
��: <
;
��< = 
prestacaoViewModel
�� 
.
�� 
StatusId
�� '
=
��( )
(
��* +
int
��+ .
)
��. /!
PrestacaoStatusEnum
��0 C
.
��C D$
EmAprovacaoOperacional
��D Z
;
��Z [ 
prestacaoViewModel
�� 
.
�� %
TipoPrestacaoSelectList
�� 6
=
��7 8(
GetAllPrestacoesSelectList
��9 S
(
��S T 
prestacaoViewModel
��T f
.
��f g
TipoId
��g m
)
��m n
;
��n o
return
�� 
View
�� 
(
��  
prestacaoViewModel
�� *
)
��* +
;
��+ ,
}
�� 	
public
�� 
IActionResult
�� 
Delete
�� #
(
��# $
int
��$ '
?
��' (
id
��) +
)
��+ ,
{
�� 	
if
�� 
(
�� 
id
�� 
==
�� 
null
�� 
)
�� 
return
�� 
NotFound
�� 
(
��  
)
��  !
;
��! "
var
�� 
	prestacao
�� 
=
�� 
_prestacaoService
�� -
.
��- .
GetById
��. 5
(
��5 6
id
��6 8
.
��8 9
Value
��9 >
)
��> ?
;
��? @
if
�� 
(
�� 
	prestacao
�� 
==
�� 
null
�� !
)
��! "
return
�� 
NotFound
�� 
(
��  
)
��  !
;
��! "
var
��  
prestacaoViewModel
�� "
=
��# $
_mapper
��% ,
.
��, -
Map
��- 0
<
��0 1 
PrestacaoViewModel
��1 C
>
��C D
(
��D E
	prestacao
��E N
)
��N O
;
��O P
if
�� 
(
�� 
	prestacao
�� 
.
�� 
ImagemComprovante
�� +
!=
��, .
null
��/ 3
)
��3 4 
prestacaoViewModel
�� "
.
��" #"
ImagemComprovanteSrc
��# 7
=
��8 9
$str
�� (
+
��) *
Convert
��+ 2
.
��2 3
ToBase64String
��3 A
(
��A B
	prestacao
��B K
.
��K L
ImagemComprovante
��L ]
)
��] ^
;
��^ _
return
�� 
View
�� 
(
��  
prestacaoViewModel
�� *
)
��* +
;
��+ ,
}
�� 	
[
�� 	
HttpPost
��	 
]
�� 
[
�� 	

ActionName
��	 
(
�� 
$str
�� 
)
�� 
]
�� 
[
�� 	&
ValidateAntiForgeryToken
��	 !
]
��! "
public
�� 
IActionResult
�� 
DeleteConfirmed
�� ,
(
��, -
int
��- 0
id
��1 3
)
��3 4
{
�� 	
_prestacaoService
�� 
.
�� 
Delete
�� $
(
��$ %
id
��% '
)
��' (
;
��( )
return
�� 
RedirectToAction
�� #
(
��# $
nameof
��$ *
(
��* +
Index
��+ 0
)
��0 1
)
��1 2
;
��2 3
}
�� 	
public
�� 
IActionResult
�� 
Details
�� $
(
��$ %
int
��% (
?
��( )
id
��* ,
)
��, -
{
�� 	
if
�� 
(
�� 
id
�� 
==
�� 
null
�� 
)
�� 
return
�� 
NotFound
�� 
(
��  
)
��  !
;
��! "
var
�� 
	prestacao
�� 
=
�� 
_prestacaoService
�� -
.
��- .
GetById
��. 5
(
��5 6
id
��6 8
.
��8 9
Value
��9 >
)
��> ?
;
��? @
if
�� 
(
�� 
	prestacao
�� 
==
�� 
null
�� !
)
��! "
return
�� 
NotFound
�� 
(
��  
)
��  !
;
��! "
var
��  
prestacaoViewModel
�� "
=
��# $
_mapper
��% ,
.
��, -
Map
��- 0
<
��0 1 
PrestacaoViewModel
��1 C
>
��C D
(
��D E
	prestacao
��E N
)
��N O
;
��O P
if
�� 
(
�� 
	prestacao
�� 
.
�� 
ImagemComprovante
�� +
!=
��, .
null
��/ 3
)
��3 4 
prestacaoViewModel
�� "
.
��" #"
ImagemComprovanteSrc
��# 7
=
��8 9
$str
�� (
+
��) *
Convert
��+ 2
.
��2 3
ToBase64String
��3 A
(
��A B
	prestacao
��B K
.
��K L
ImagemComprovante
��L ]
)
��] ^
;
��^ _
return
�� 
View
�� 
(
��  
prestacaoViewModel
�� *
)
��* +
;
��+ ,
}
�� 	
public
�� 
IActionResult
�� 
Edit
�� !
(
��! "
int
��" %
?
��% &
id
��' )
)
��) *
{
�� 	
if
�� 
(
�� 
id
�� 
==
�� 
null
�� 
)
�� 
return
�� 
NotFound
�� 
(
��  
)
��  !
;
��! "
var
�� 
	prestacao
�� 
=
�� 
_prestacaoService
�� -
.
��- .
GetById
��. 5
(
��5 6
id
��6 8
.
��8 9
Value
��9 >
)
��> ?
;
��? @
if
�� 
(
�� 
	prestacao
�� 
==
�� 
null
�� !
)
��! "
return
�� 
NotFound
�� 
(
��  
)
��  !
;
��! "
var
�� 
usuarioLogado
�� 
=
�� 
GetLoggedUser
��  -
(
��- .
)
��. /
;
��/ 0
if
�� 
(
�� 
	prestacao
�� 
.
�� 

EmitenteId
�� $
!=
��% '
usuarioLogado
��( 5
.
��5 6
Id
��6 8
)
��8 9
return
�� 
Forbid
�� 
(
�� 
)
�� 
;
��  
var
��  
prestacaoViewModel
�� "
=
��# $
_mapper
��% ,
.
��, -
Map
��- 0
<
��0 1 
PrestacaoViewModel
��1 C
>
��C D
(
��D E
	prestacao
��E N
)
��N O
;
��O P 
prestacaoViewModel
�� 
.
�� 
AprovadorId
�� *
=
��+ ,
usuarioLogado
��- :
.
��: ;
	GerenteId
��; D
;
��D E 
prestacaoViewModel
�� 
.
�� #
AprovadorFinanceiroId
�� 4
=
��5 6
usuarioLogado
��7 D
.
��D E!
GerenteFinanceiroId
��E X
;
��X Y 
prestacaoViewModel
�� 
.
�� 

EmitenteId
�� )
=
��* +
usuarioLogado
��, 9
.
��9 :
Id
��: <
;
��< = 
prestacaoViewModel
�� 
.
�� 
StatusId
�� '
=
��( )
	prestacao
��* 3
.
��3 4
StatusId
��4 <
;
��< = 
prestacaoViewModel
�� 
.
�� %
TipoPrestacaoSelectList
�� 6
=
��7 8(
GetAllPrestacoesSelectList
��9 S
(
��S T 
prestacaoViewModel
��T f
.
��f g
TipoId
��g m
)
��m n
;
��n o
return
�� 
View
�� 
(
��  
prestacaoViewModel
�� *
)
��* +
;
��+ ,
}
�� 	
[
�� 	
HttpPost
��	 
]
�� 
[
�� 	&
ValidateAntiForgeryToken
��	 !
]
��! "
public
�� 
IActionResult
�� 
Edit
�� !
(
��! "
int
��" %
id
��& (
,
��( ) 
PrestacaoViewModel
��* < 
prestacaoViewModel
��= O
)
��O P
{
�� 	
var
�� 
usuarioLogado
�� 
=
�� 
GetLoggedUser
��  -
(
��- .
)
��. /
;
��/ 0
if
�� 
(
�� 
id
�� 
!=
��  
prestacaoViewModel
�� (
.
��( )
Id
��) +
)
��+ ,
return
�� 
NotFound
�� 
(
��  
)
��  !
;
��! "
if
�� 
(
��  
prestacaoViewModel
�� "
.
��" #

EmitenteId
��# -
!=
��. 0
usuarioLogado
��1 >
.
��> ?
Id
��? A
)
��A B
return
�� 
Forbid
�� 
(
�� 
)
�� 
;
��  
if
�� 
(
�� 

ModelState
�� 
.
�� 
IsValid
�� "
)
��" #
{
�� 
try
�� 
{
�� 
var
�� 
	prestacao
�� !
=
��" #
_mapper
��$ +
.
��+ ,
Map
��, /
<
��/ 0
	Prestacao
��0 9
>
��9 :
(
��: ; 
prestacaoViewModel
��; M
)
��M N
;
��N O
	prestacao
�� 
.
�� 
ImagemComprovante
�� /
=
��0 1
GetImageBytes
��2 ?
(
��? @ 
prestacaoViewModel
��@ R
.
��R S
ImagemComprovante
��S d
)
��d e
;
��e f
_prestacaoService
�� %
.
��% &
Update
��& ,
(
��, -
	prestacao
��- 6
)
��6 7
;
��7 8
}
�� 
catch
�� 
(
�� *
DbUpdateConcurrencyException
�� 3
)
��3 4
{
�� 
if
�� 
(
�� 
!
�� 
_prestacaoService
�� *
.
��* +
Exists
��+ 1
(
��1 2 
prestacaoViewModel
��2 D
.
��D E
Id
��E G
)
��G H
)
��H I
return
�� 
NotFound
�� '
(
��' (
)
��( )
;
��) *
throw
�� 
;
�� 
}
�� 
return
�� 
RedirectToAction
�� '
(
��' (
nameof
��( .
(
��. /
Index
��/ 4
)
��4 5
)
��5 6
;
��6 7
}
�� 
;
��  
prestacaoViewModel
�� 
.
�� 
AprovadorId
�� *
=
��+ ,
usuarioLogado
��- :
.
��: ;
	GerenteId
��; D
;
��D E 
prestacaoViewModel
�� 
.
�� #
AprovadorFinanceiroId
�� 4
=
��5 6
usuarioLogado
��7 D
.
��D E!
GerenteFinanceiroId
��E X
;
��X Y 
prestacaoViewModel
�� 
.
�� 

EmitenteId
�� )
=
��* +
usuarioLogado
��, 9
.
��9 :
Id
��: <
;
��< = 
prestacaoViewModel
�� 
.
�� 
StatusId
�� '
=
��( )
(
��* +
int
��+ .
)
��. /!
PrestacaoStatusEnum
��0 C
.
��C D$
EmAprovacaoOperacional
��D Z
;
��Z [ 
prestacaoViewModel
�� 
.
�� %
TipoPrestacaoSelectList
�� 6
=
��7 8(
GetAllPrestacoesSelectList
��9 S
(
��S T 
prestacaoViewModel
��T f
.
��f g
TipoId
��g m
)
��m n
;
��n o
return
�� 
View
�� 
(
��  
prestacaoViewModel
�� *
)
��* +
;
��+ ,
}
�� 	
public
�� 
IActionResult
�� 
Index
�� "
(
��" #
int
��# &
page
��' +
=
��, -
$num
��. /
)
��/ 0
{
�� 	
var
�� 
todasPrestacoes
�� 
=
��  !
_prestacaoService
��" 3
.
��3 4 
GetAllByEmitenteId
��4 F
(
��F G
GetLoggedUser
��G T
(
��T U
)
��U V
.
��V W
Id
��W Y
)
��Y Z
;
��Z [
var
�� 
prestacoesLista
�� 
=
��  !
todasPrestacoes
��" 1
.
��1 2
OrderByDescending
��2 C
(
��C D
pr
��D F
=>
��G I
pr
��J L
.
��L M
Data
��M Q
)
��Q R
.
�� 
Skip
�� 
(
�� 
(
�� 
page
�� 
-
�� 
$num
�� 
)
��  
*
��! "
	Constants
��# ,
.
��, -
PageSize
��- 5
)
��5 6
.
��6 7
Take
��7 ;
(
��; <
	Constants
��< E
.
��E F
PageSize
��F N
)
��N O
;
��O P
var
�� %
prestacoesListViewModel
�� '
=
��( )
new
��* -$
PrestacaoListViewModel
��. D
{
�� 

PageNumber
�� 
=
�� 
page
�� !
,
��! "
TotalRecords
�� 
=
�� 
todasPrestacoes
�� .
.
��. /
Count
��/ 4
(
��4 5
)
��5 6
,
��6 7
PrestacoesList
�� 
=
��  
_mapper
��! (
.
��( )
Map
��) ,
<
��, -
List
��- 1
<
��1 2
	Prestacao
��2 ;
>
��; <
,
��< =
List
��> B
<
��B C 
PrestacaoViewModel
��C U
>
��U V
>
��V W
(
��W X
prestacoesLista
��X g
.
��g h
ToList
��h n
(
��n o
)
��o p
)
��p q
}
�� 
;
�� 
return
�� 
View
�� 
(
�� %
prestacoesListViewModel
�� /
)
��/ 0
;
��0 1
}
�� 	
public
�� 
IActionResult
�� #
PrestacoesParaAprovar
�� 2
(
��2 3
int
��3 6
page
��7 ;
=
��< =
$num
��> ?
)
��? @
{
�� 	
var
�� 
todasPrestacoes
�� 
=
��  !
_prestacaoService
�� !
.
��! "!
GetAllParaAprovacao
��" 5
(
��5 6
GetLoggedUser
��6 C
(
��C D
)
��D E
.
��E F
Id
��F H
,
��H I!
PrestacaoStatusEnum
��J ]
.
��] ^$
EmAprovacaoOperacional
��^ t
)
��t u
;
��u v
var
�� 
prestacoesLista
�� 
=
��  !
todasPrestacoes
��" 1
.
��1 2
OrderByDescending
��2 C
(
��C D
pr
��D F
=>
��G I
pr
��J L
.
��L M
Data
��M Q
)
��Q R
.
�� 
Skip
�� 
(
�� 
(
�� 
page
�� 
-
�� 
$num
�� 
)
��  
*
��! "
	Constants
��# ,
.
��, -
PageSize
��- 5
)
��5 6
.
��6 7
Take
��7 ;
(
��; <
	Constants
��< E
.
��E F
PageSize
��F N
)
��N O
;
��O P
var
�� %
prestacoesListViewModel
�� '
=
��( )
new
��* -$
PrestacaoListViewModel
��. D
{
�� 

PageNumber
�� 
=
�� 
page
�� !
,
��! "
TotalRecords
�� 
=
�� 
todasPrestacoes
�� .
.
��. /
Count
��/ 4
(
��4 5
)
��5 6
,
��6 7
PrestacoesList
�� 
=
��  
_mapper
��! (
.
��( )
Map
��) ,
<
��, -
List
��- 1
<
��1 2
	Prestacao
��2 ;
>
��; <
,
��< =
List
��> B
<
��B C 
PrestacaoViewModel
��C U
>
��U V
>
��V W
(
��W X
prestacoesLista
��X g
.
��g h
ToList
��h n
(
��n o
)
��o p
)
��p q
}
�� 
;
�� 
return
�� 
View
�� 
(
�� %
prestacoesListViewModel
�� /
)
��/ 0
;
��0 1
}
�� 	
public
�� 
IActionResult
�� -
PrestacoesParaAprovarFinanceiro
�� <
(
��< =
int
��= @
page
��A E
=
��F G
$num
��H I
)
��I J
{
�� 	
var
�� 
todasPrestacoes
�� 
=
��  !
_prestacaoService
�� !
.
��! "!
GetAllParaAprovacao
��" 5
(
��5 6
GetLoggedUser
��6 C
(
��C D
)
��D E
.
��E F
Id
��F H
,
��H I!
PrestacaoStatusEnum
��J ]
.
��] ^#
EmAprovacaoFinanceira
��^ s
)
��s t
;
��t u
var
�� 
prestacoesLista
�� 
=
��  !
todasPrestacoes
��" 1
.
��1 2
OrderByDescending
��2 C
(
��C D
pr
��D F
=>
��G I
pr
��J L
.
��L M
Data
��M Q
)
��Q R
.
�� 
Skip
�� 
(
�� 
(
�� 
page
�� 
-
�� 
$num
�� 
)
��  
*
��! "
	Constants
��# ,
.
��, -
PageSize
��- 5
)
��5 6
.
��6 7
Take
��7 ;
(
��; <
	Constants
��< E
.
��E F
PageSize
��F N
)
��N O
;
��O P
var
�� %
prestacoesListViewModel
�� '
=
��( )
new
��* -$
PrestacaoListViewModel
��. D
{
�� 

PageNumber
�� 
=
�� 
page
�� !
,
��! "
TotalRecords
�� 
=
�� 
todasPrestacoes
�� .
.
��. /
Count
��/ 4
(
��4 5
)
��5 6
,
��6 7
PrestacoesList
�� 
=
��  
_mapper
��! (
.
��( )
Map
��) ,
<
��, -
List
��- 1
<
��1 2
	Prestacao
��2 ;
>
��; <
,
��< =
List
��> B
<
��B C 
PrestacaoViewModel
��C U
>
��U V
>
��V W
(
��W X
prestacoesLista
��X g
.
��g h
ToList
��h n
(
��n o
)
��o p
)
��p q
}
�� 
;
�� 
return
�� 
View
�� 
(
�� %
prestacoesListViewModel
�� /
)
��/ 0
;
��0 1
}
�� 	
public
�� 
async
�� 
Task
�� 
<
�� 
IActionResult
�� '
>
��' (
Print
��) .
(
��. /
int
��/ 2
?
��2 3
id
��4 6
)
��6 7
{
�� 	
if
�� 
(
�� 
id
�� 
==
�� 
null
�� 
)
�� 
return
�� 
NotFound
�� 
(
��  
)
��  !
;
��! "
var
�� 
	prestacao
�� 
=
�� 
_prestacaoService
�� -
.
��- .
GetById
��. 5
(
��5 6
id
��6 8
.
��8 9
Value
��9 >
)
��> ?
;
��? @
if
�� 
(
�� 
	prestacao
�� 
==
�� 
null
�� !
)
��! "
return
�� 
NotFound
�� 
(
��  
)
��  !
;
��! "
var
��  
prestacaoViewModel
�� "
=
��# $
_mapper
��% ,
.
��, -
Map
��- 0
<
��0 1 
PrestacaoViewModel
��1 C
>
��C D
(
��D E
	prestacao
��E N
)
��N O
;
��O P
if
�� 
(
�� 
	prestacao
�� 
.
�� 
ImagemComprovante
�� +
!=
��, .
null
��/ 3
)
��3 4 
prestacaoViewModel
�� "
.
��" #"
ImagemComprovanteSrc
��# 7
=
��8 9
$str
�� (
+
��) *
Convert
��+ 2
.
��2 3
ToBase64String
��3 A
(
��A B
	prestacao
��B K
.
��K L
ImagemComprovante
��L ]
)
��] ^
;
��^ _
var
��  
jsReportingService
�� "
=
��# $
new
��% (
ReportingService
��) 9
(
��9 :
_jsReportSettings
��: K
.
��K L
Uri
��L O
,
��O P
_jsReportSettings
�� !
.
��! "
UsernameEmail
��" /
,
��/ 0
_jsReportSettings
��1 B
.
��B C
UsernamePassword
��C S
)
��S T
;
��T U
var
�� 
htmlToRender
�� 
=
�� 
await
�� $ 
_viewRenderService
��% 7
.
��7 8!
RenderToStringAsync
��8 K
(
��K L
$str
��L m
,
��m n 
prestacaoViewModel
�� "
)
��" #
;
��# $
var
�� 
report
�� 
=
�� 
await
��  
jsReportingService
�� 1
.
��1 2
RenderAsync
��2 =
(
��= >
new
��> A
RenderRequest
��B O
{
�� 
Template
�� 
=
�� 
new
�� 
Template
�� '
{
�� 
Recipe
�� 
=
�� 
Recipe
�� #
.
��# $
	ChromePdf
��$ -
,
��- .
Engine
�� 
=
�� 
Engine
�� #
.
��# $

Handlebars
��$ .
,
��. /
Content
�� 
=
�� 
htmlToRender
�� *
}
�� 
}
�� 
)
�� 
;
�� 
return
�� 
new
�� 
FileStreamResult
�� '
(
��' (
report
��( .
.
��. /
Content
��/ 6
,
��6 7
$str
��8 I
)
��I J
;
��J K
}
�� 	
public
�� 
IActionResult
�� 
Reject
�� #
(
��# $
int
��$ '
?
��' (
id
��) +
)
��+ ,
{
�� 	
if
�� 
(
�� 
id
�� 
==
�� 
null
�� 
)
�� 
return
�� 
NotFound
�� 
(
��  
)
��  !
;
��! "
var
�� 
	prestacao
�� 
=
�� 
_prestacaoService
�� -
.
��- .
GetById
��. 5
(
��5 6
id
��6 8
.
��8 9
Value
��9 >
)
��> ?
;
��? @
if
�� 
(
�� 
	prestacao
�� 
==
�� 
null
�� !
)
��! "
return
�� 
NotFound
�� 
(
��  
)
��  !
;
��! "
var
��  
prestacaoViewModel
�� "
=
��# $
_mapper
��% ,
.
��, -
Map
��- 0
<
��0 1 
PrestacaoViewModel
��1 C
>
��C D
(
��D E
	prestacao
��E N
)
��N O
;
��O P
if
�� 
(
�� 
	prestacao
�� 
.
�� 
ImagemComprovante
�� +
!=
��, .
null
��/ 3
)
��3 4 
prestacaoViewModel
�� "
.
��" #"
ImagemComprovanteSrc
��# 7
=
��8 9
$str
�� (
+
��) *
Convert
��+ 2
.
��2 3
ToBase64String
��3 A
(
��A B
	prestacao
��B K
.
��K L
ImagemComprovante
��L ]
)
��] ^
;
��^ _
return
�� 
View
�� 
(
��  
prestacaoViewModel
�� *
)
��* +
;
��+ ,
}
�� 	
[
�� 	
HttpPost
��	 
]
�� 
[
�� 	

ActionName
��	 
(
�� 
$str
�� 
)
�� 
]
�� 
[
�� 	&
ValidateAntiForgeryToken
��	 !
]
��! "
public
�� 
IActionResult
�� 
RejectConfirmed
�� ,
(
��, -
int
��- 0
id
��1 3
,
��3 4
string
��5 ;$
justificativaAprovacao
��< R
)
��R S
{
�� 	
_prestacaoService
�� 
.
�� 
RejeitarPrestacao
�� /
(
��/ 0
id
��0 2
,
��2 3$
justificativaAprovacao
��4 J
,
��J K!
PrestacaoStatusEnum
��L _
.
��_ `$
EmAprovacaoOperacional
��` v
)
��v w
;
��w x
return
�� 
RedirectToAction
�� #
(
��# $
nameof
��$ *
(
��* +#
PrestacoesParaAprovar
��+ @
)
��@ A
)
��A B
;
��B C
}
�� 	
public
�� 
IActionResult
�� 
RejectFinanceiro
�� -
(
��- .
int
��. 1
?
��1 2
id
��3 5
)
��5 6
{
�� 	
if
�� 
(
�� 
id
�� 
==
�� 
null
�� 
)
�� 
return
�� 
NotFound
�� 
(
��  
)
��  !
;
��! "
var
�� 
	prestacao
�� 
=
�� 
_prestacaoService
�� -
.
��- .
GetById
��. 5
(
��5 6
id
��6 8
.
��8 9
Value
��9 >
)
��> ?
;
��? @
if
�� 
(
�� 
	prestacao
�� 
==
�� 
null
�� !
)
��! "
return
�� 
NotFound
�� 
(
��  
)
��  !
;
��! "
var
��  
prestacaoViewModel
�� "
=
��# $
_mapper
��% ,
.
��, -
Map
��- 0
<
��0 1 
PrestacaoViewModel
��1 C
>
��C D
(
��D E
	prestacao
��E N
)
��N O
;
��O P
if
�� 
(
�� 
	prestacao
�� 
.
�� 
ImagemComprovante
�� +
!=
��, .
null
��/ 3
)
��3 4 
prestacaoViewModel
�� "
.
��" #"
ImagemComprovanteSrc
��# 7
=
��8 9
$str
�� (
+
��) *
Convert
��+ 2
.
��2 3
ToBase64String
��3 A
(
��A B
	prestacao
��B K
.
��K L
ImagemComprovante
��L ]
)
��] ^
;
��^ _
return
�� 
View
�� 
(
��  
prestacaoViewModel
�� *
)
��* +
;
��+ ,
}
�� 	
[
�� 	
HttpPost
��	 
]
�� 
[
�� 	

ActionName
��	 
(
�� 
$str
�� &
)
��& '
]
��' (
[
�� 	&
ValidateAntiForgeryToken
��	 !
]
��! "
public
�� 
IActionResult
�� '
RejectFinanceiroConfirmed
�� 6
(
��6 7
int
��7 :
id
��; =
,
��= >
string
��? E.
 justificativaAprovacaoFinanceira
��F f
)
��f g
{
�� 	
_prestacaoService
�� 
.
�� 
RejeitarPrestacao
�� /
(
��/ 0
id
��0 2
,
��2 3.
 justificativaAprovacaoFinanceira
��4 T
,
��T U!
PrestacaoStatusEnum
�� #
.
��# $#
EmAprovacaoFinanceira
��$ 9
)
��9 :
;
��: ;
return
�� 
RedirectToAction
�� #
(
��# $
nameof
��$ *
(
��* +-
PrestacoesParaAprovarFinanceiro
��+ J
)
��J K
)
��K L
;
��L M
}
�� 	
private
�� 

SelectList
�� (
GetAllPrestacoesSelectList
�� 5
(
��5 6
)
��6 7
{
�� 	
return
�� 
new
�� 

SelectList
�� !
(
��! "
_prestacaoService
��" 3
.
��3 4"
GetAllPrestacaoTipos
��4 H
(
��H I
)
��I J
,
��J K
$str
��L P
,
��P Q
$str
��R X
)
��X Y
;
��Y Z
}
�� 	
private
�� 

SelectList
�� (
GetAllPrestacoesSelectList
�� 5
(
��5 6
int
��6 9
tipoId
��: @
)
��@ A
{
�� 	
return
�� 
new
�� 

SelectList
�� !
(
��! "
_prestacaoService
��" 3
.
��3 4"
GetAllPrestacaoTipos
��4 H
(
��H I
)
��I J
,
��J K
$str
��L P
,
��P Q
$str
��R X
,
��X Y
tipoId
��Z `
)
��` a
;
��a b
}
�� 	
private
�� 
static
�� 
byte
�� 
[
�� 
]
�� 
GetImageBytes
�� +
(
��+ ,
	IFormFile
��, 5
image
��6 ;
)
��; <
{
�� 	
if
�� 
(
�� 
image
�� 
==
�� 
null
�� 
)
�� 
return
�� 
null
�� 
;
�� 
if
�� 
(
�� 
image
�� 
.
�� 
Length
�� 
<=
�� 
$num
��  !
)
��! "
return
�� 
null
�� 
;
�� 
byte
�� 
[
�� 
]
�� 
	imageByte
�� 
;
�� 
using
�� 
(
�� 
var
�� 

readStream
�� !
=
��" #
image
��$ )
.
��) *
OpenReadStream
��* 8
(
��8 9
)
��9 :
)
��: ;
using
�� 
(
�� 
var
�� 
memoryStream
�� #
=
��$ %
new
��& )
MemoryStream
��* 6
(
��6 7
)
��7 8
)
��8 9
{
�� 

readStream
�� 
.
�� 
CopyTo
�� !
(
��! "
memoryStream
��" .
)
��. /
;
��/ 0
	imageByte
�� 
=
�� 
memoryStream
�� (
.
��( )
ToArray
��) 0
(
��0 1
)
��1 2
;
��2 3
}
�� 
return
�� 
	imageByte
�� 
;
�� 
}
�� 	
}
�� 
}�� �x
UC:\projects\personal\prestasys\Unisul.PrestaSys.Web\Controllers\UsuariosController.cs
	namespace 	
Unisul
 
. 
	PrestaSys 
. 
Web 
. 
Controllers *
{ 
public 

class 
UsuariosController #
:$ %
BaseController& 4
{ 
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
IUsuarioService (
_usuarioService) 8
;8 9
public 
UsuariosController !
(! "
IUsuarioService" 1
usuarioService2 @
,@ A
IMapperB I
mapperJ P
)P Q
:R S
baseT X
(X Y
usuarioServiceY g
)g h
{ 	
_usuarioService 
= 
usuarioService ,
;, -
_mapper 
= 
mapper 
; 
} 	
public 
IActionResult 
Create #
(# $
)$ %
{ 	
var 
usuarioViewModel  
=! "
new# &
UsuarioViewModel' 7
{ 
GerenteSelectList !
=" #$
GetAllGerentesSelectList$ <
(< =
)= >
,> ?'
GerenteFinanceiroSelectList   +
=  , -/
#GetAllGerentesFinanceirosSelectList  . Q
(  Q R
)  R S
}!! 
;!! 
return## 
View## 
(## 
usuarioViewModel## (
)##( )
;##) *
}$$ 	
['' 	
HttpPost''	 
]'' 
[(( 	$
ValidateAntiForgeryToken((	 !
]((! "
public)) 
IActionResult)) 
Create)) #
())# $
UsuarioViewModel))$ 4
usuarioViewModel))5 E
)))E F
{** 	
if++ 
(++ 

ModelState++ 
.++ 
IsValid++ "
)++" #
try,, 
{-- 
_usuarioService.. #
...# $
Create..$ *
(..* +
_mapper..+ 2
...2 3
Map..3 6
<..6 7
Usuario..7 >
>..> ?
(..? @
usuarioViewModel..@ P
)..P Q
)..Q R
;..R S
return// 
RedirectToAction// +
(//+ ,
nameof//, 2
(//2 3
Index//3 8
)//8 9
)//9 :
;//: ;
}00 
catch11 
(11 
DbUpdateException11 (
ex11) +
)11+ ,
{22 
if33 
(33 
ex33 
.33 
InnerException33 )
.33) *
Message33* 1
.331 2
Contains332 :
(33: ;
$str44 u
)44u v
)44v w

ModelState55 "
.55" #
AddModelError55# 0
(550 1
string551 7
.557 8
Empty558 =
,55= >
$str66 r
)66r s
;66s t
}77 
usuarioViewModel99 
.99 
GerenteSelectList99 .
=99/ 0$
GetAllGerentesSelectList991 I
(99I J
)99J K
;99K L
usuarioViewModel:: 
.:: '
GerenteFinanceiroSelectList:: 8
=::9 :/
#GetAllGerentesFinanceirosSelectList::; ^
(::^ _
)::_ `
;::` a
return<< 
View<< 
(<< 
usuarioViewModel<< (
)<<( )
;<<) *
}== 	
public@@ 
IActionResult@@ 
Delete@@ #
(@@# $
int@@$ '
?@@' (
id@@) +
)@@+ ,
{AA 	
ifBB 
(BB 
idBB 
==BB 
nullBB 
)BB 
returnCC 
NotFoundCC 
(CC  
)CC  !
;CC! "
varEE 
usuarioEE 
=EE 
_usuarioServiceEE )
.EE) *
GetByIdEE* 1
(EE1 2
idEE2 4
.EE4 5
ValueEE5 :
)EE: ;
;EE; <
ifGG 
(GG 
usuarioGG 
==GG 
nullGG 
)GG  
returnHH 
NotFoundHH 
(HH  
)HH  !
;HH! "
returnJJ 
ViewJJ 
(JJ 
_mapperJJ 
.JJ  
MapJJ  #
<JJ# $
UsuarioViewModelJJ$ 4
>JJ4 5
(JJ5 6
usuarioJJ6 =
)JJ= >
)JJ> ?
;JJ? @
}KK 	
[NN 	
HttpPostNN	 
]NN 
[OO 	

ActionNameOO	 
(OO 
$strOO 
)OO 
]OO 
[PP 	$
ValidateAntiForgeryTokenPP	 !
]PP! "
publicQQ 
IActionResultQQ 
DeleteConfirmedQQ ,
(QQ, -
intQQ- 0
idQQ1 3
)QQ3 4
{RR 	
_usuarioServiceSS 
.SS 
DeleteSS "
(SS" #
idSS# %
)SS% &
;SS& '
returnTT 
RedirectToActionTT #
(TT# $
nameofTT$ *
(TT* +
IndexTT+ 0
)TT0 1
)TT1 2
;TT2 3
}UU 	
publicXX 
IActionResultXX 
DetailsXX $
(XX$ %
intXX% (
?XX( )
idXX* ,
)XX, -
{YY 	
ifZZ 
(ZZ 
idZZ 
==ZZ 
nullZZ 
)ZZ 
return[[ 
NotFound[[ 
([[  
)[[  !
;[[! "
var]] 
usuario]] 
=]] 
_usuarioService]] )
.]]) *
GetById]]* 1
(]]1 2
id]]2 4
.]]4 5
Value]]5 :
)]]: ;
;]]; <
if__ 
(__ 
usuario__ 
==__ 
null__ 
)__  
return`` 
NotFound`` 
(``  
)``  !
;``! "
returnbb 
Viewbb 
(bb 
_mapperbb 
.bb  
Mapbb  #
<bb# $
UsuarioViewModelbb$ 4
>bb4 5
(bb5 6
usuariobb6 =
)bb= >
)bb> ?
;bb? @
}cc 	
publicff 
IActionResultff 
Editff !
(ff! "
intff" %
?ff% &
idff' )
)ff) *
{gg 	
ifhh 
(hh 
idhh 
==hh 
nullhh 
)hh 
returnii 
NotFoundii 
(ii  
)ii  !
;ii! "
varkk 
usuariokk 
=kk 
_usuarioServicekk )
.kk) *
GetByIdkk* 1
(kk1 2
idkk2 4
.kk4 5
Valuekk5 :
)kk: ;
;kk; <
ifmm 
(mm 
usuariomm 
==mm 
nullmm 
)mm  
returnnn 
NotFoundnn 
(nn  
)nn  !
;nn! "
varpp 
usuarioViewModelpp  
=pp! "
_mapperpp# *
.pp* +
Mappp+ .
<pp. /
UsuarioViewModelpp/ ?
>pp? @
(pp@ A
usuarioppA H
)ppH I
;ppI J
usuarioViewModelrr 
.rr 
GerenteSelectListrr .
=rr/ 0$
GetAllGerentesSelectListrr1 I
(rrI J
)rrJ K
;rrK L
usuarioViewModelss 
.ss '
GerenteFinanceiroSelectListss 8
=ss9 :/
#GetAllGerentesFinanceirosSelectListss; ^
(ss^ _
)ss_ `
;ss` a
returnuu 
Viewuu 
(uu 
usuarioViewModeluu (
)uu( )
;uu) *
}vv 	
[yy 	
HttpPostyy	 
]yy 
[zz 	$
ValidateAntiForgeryTokenzz	 !
]zz! "
public{{ 
IActionResult{{ 
Edit{{ !
({{! "
int{{" %
id{{& (
,{{( )
UsuarioViewModel{{* :
usuarioViewModel{{; K
){{K L
{|| 	
if}} 
(}} 
id}} 
!=}} 
usuarioViewModel}} &
.}}& '
Id}}' )
)}}) *
return~~ 
NotFound~~ 
(~~  
)~~  !
;~~! "
if
�� 
(
�� 

ModelState
�� 
.
�� 
IsValid
�� "
)
��" #
try
�� 
{
�� 
_usuarioService
�� #
.
��# $
Update
��$ *
(
��* +
_mapper
��+ 2
.
��2 3
Map
��3 6
<
��6 7
Usuario
��7 >
>
��> ?
(
��? @
usuarioViewModel
��@ P
)
��P Q
)
��Q R
;
��R S
return
�� 
RedirectToAction
�� +
(
��+ ,
nameof
��, 2
(
��2 3
Index
��3 8
)
��8 9
)
��9 :
;
��: ;
}
�� 
catch
�� 
(
�� 
	Exception
��  
ex
��! #
)
��# $
{
�� 
switch
�� 
(
�� 
ex
�� 
)
�� 
{
�� 
case
�� *
DbUpdateConcurrencyException
�� 9
_
��: ;
when
��< @
!
��A B
_usuarioService
��B Q
.
��Q R
Exists
��R X
(
��X Y
usuarioViewModel
��Y i
.
��i j
Id
��j l
)
��l m
:
��m n
return
�� "
NotFound
��# +
(
��+ ,
)
��, -
;
��- .
case
�� *
DbUpdateConcurrencyException
�� 9
_
��: ;
:
��; <
throw
�� !
;
��! "
case
�� 
DbUpdateException
�� .
_
��/ 0
when
��1 5
ex
��6 8
.
��8 9
InnerException
��9 G
.
��G H
Message
��H O
.
��O P
Contains
��P X
(
��X Y
$str
��  }
)
��} ~
:
�� 

ModelState
�� &
.
��& '
AddModelError
��' 4
(
��4 5
string
��5 ;
.
��; <
Empty
��< A
,
��A B
$str
��  v
)
��v w
;
��w x
break
�� !
;
��! "
default
�� 
:
��  
return
�� "
RedirectToAction
��# 3
(
��3 4
nameof
��4 :
(
��: ;
Index
��; @
)
��@ A
)
��A B
;
��B C
}
�� 
}
�� 
usuarioViewModel
�� 
.
�� 
GerenteSelectList
�� .
=
��/ 0&
GetAllGerentesSelectList
��1 I
(
��I J
)
��J K
;
��K L
usuarioViewModel
�� 
.
�� )
GerenteFinanceiroSelectList
�� 8
=
��9 :1
#GetAllGerentesFinanceirosSelectList
��; ^
(
��^ _
)
��_ `
;
��` a
return
�� 
View
�� 
(
�� 
usuarioViewModel
�� (
)
��( )
;
��) *
}
�� 	
public
�� 
IActionResult
�� 
Index
�� "
(
��" #
int
��# &
page
��' +
=
��, -
$num
��. /
)
��/ 0
{
�� 	
var
�� 
todosUsuarios
�� 
=
�� 
_usuarioService
��  /
.
��/ 0
GetAll
��0 6
(
��6 7
)
��7 8
;
��8 9
var
�� 
usuariosLista
�� 
=
�� 
todosUsuarios
��  -
.
�� 
OrderBy
�� 
(
�� 
u
�� 
=>
�� 
u
�� 
.
��  
Nome
��  $
)
��$ %
.
�� 
Skip
�� 
(
�� 
(
�� 
page
�� 
-
�� 
$num
�� 
)
��  
*
��! "
	Constants
��# ,
.
��, -
PageSize
��- 5
)
��5 6
.
�� 
Take
�� 
(
�� 
	Constants
�� 
.
��  
PageSize
��  (
)
��( )
;
��) *
var
�� #
usuariosListViewModel
�� %
=
��& '
new
��( +"
UsuarioListViewModel
��, @
{
�� 

PageNumber
�� 
=
�� 
page
�� !
,
��! "
TotalRecords
�� 
=
�� 
todosUsuarios
�� ,
.
��, -
Count
��- 2
(
��2 3
)
��3 4
,
��4 5
UsuariosList
�� 
=
�� 
_mapper
�� &
.
��& '
Map
��' *
<
��* +
List
��+ /
<
��/ 0
Usuario
��0 7
>
��7 8
,
��8 9
List
��: >
<
��> ?
UsuarioViewModel
��? O
>
��O P
>
��P Q
(
��Q R
usuariosLista
��R _
.
��_ `
ToList
��` f
(
��f g
)
��g h
)
��h i
}
�� 
;
�� 
return
�� 
View
�� 
(
�� #
usuariosListViewModel
�� -
)
��- .
;
��. /
}
�� 	
private
�� 

SelectList
�� 1
#GetAllGerentesFinanceirosSelectList
�� >
(
��> ?
)
��? @
{
�� 	
var
�� !
gerentesFinanceiros
�� #
=
��$ %
_usuarioService
��& 5
.
��5 6'
GetAllGerentesFinanceiros
��6 O
(
��O P
)
��P Q
.
��Q R
Select
��R X
(
��X Y
x
��Y Z
=>
��[ ]
new
��^ a
{
�� 
x
�� 
.
�� 
Id
�� 
,
�� 
NomeCompleto
�� 
=
�� 
x
��  
.
��  !
Nome
��! %
+
��& '
$str
��( +
+
��, -
x
��. /
.
��/ 0
	Sobrenome
��0 9
.
��9 :
ToString
��: B
(
��B C
)
��C D
}
�� 
)
�� 
;
�� 
return
�� 
new
�� 

SelectList
�� !
(
��! "!
gerentesFinanceiros
��" 5
,
��5 6
$str
��7 ;
,
��; <
$str
��= K
)
��K L
;
��L M
}
�� 	
private
�� 

SelectList
�� &
GetAllGerentesSelectList
�� 3
(
��3 4
)
��4 5
{
�� 	
var
�� 
gerentes
�� 
=
�� 
_usuarioService
�� *
.
��* +
GetAllGerentes
��+ 9
(
��9 :
)
��: ;
.
��; <
Select
��< B
(
��B C
x
��C D
=>
��E G
new
��H K
{
�� 
x
�� 
.
�� 
Id
�� 
,
�� 
NomeCompleto
�� 
=
�� 
x
��  
.
��  !
Nome
��! %
+
��& '
$str
��( +
+
��, -
x
��. /
.
��/ 0
	Sobrenome
��0 9
.
��9 :
ToString
��: B
(
��B C
)
��C D
}
�� 
)
�� 
;
�� 
return
�� 
new
�� 

SelectList
�� !
(
��! "
gerentes
��" *
,
��* +
$str
��, 0
,
��0 1
$str
��2 @
)
��@ A
;
��A B
}
�� 	
}
�� 
}�� �
OC:\projects\personal\prestasys\Unisul.PrestaSys.Web\Mappings\MappingProfiles.cs
	namespace 	
Unisul
 
. 
	PrestaSys 
. 
Web 
. 
Mappings '
{ 
public		 

class		 
MappingProfiles		  
:		! "
Profile		# *
{

 
public 
MappingProfiles 
( 
)  
{ 	
	CreateMap 
< 
Usuario 
, 
UsuarioViewModel /
>/ 0
(0 1
)1 2
.2 3

ReverseMap3 =
(= >
)> ?
;? @
	CreateMap 
< 
	Prestacao 
,  
PrestacaoViewModel! 3
>3 4
(4 5
)5 6
.6 7
	ForMember7 @
(@ A
xA B
=>C E
xF G
.G H
ImagemComprovanteH Y
,Y Z
opt[ ^
=>_ a
optb e
.e f
Ignoref l
(l m
)m n
)n o
;o p
	CreateMap 
< 
PrestacaoViewModel (
,( )
	Prestacao* 3
>3 4
(4 5
)5 6
.6 7
	ForMember7 @
(@ A
xA B
=>C E
xF G
.G H
ImagemComprovanteH Y
,Y Z
opt[ ^
=>_ a
optb e
.e f
Ignoref l
(l m
)m n
)n o
;o p
} 	
} 
} �
PC:\projects\personal\prestasys\Unisul.PrestaSys.Web\Models\Base\BaseViewModel.cs
	namespace 	
Unisul
 
. 
	PrestaSys 
. 
Web 
. 
Models %
.% &
Base& *
{ 
public 

class 
BaseViewModel 
{ 
public 

DadosLogin 
UsuarioLogado '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
} 
} �	
PC:\projects\personal\prestasys\Unisul.PrestaSys.Web\Models\Base\UsuarioLogado.cs
	namespace 	
Unisul
 
. 
	PrestaSys 
. 
Web 
. 
Models %
.% &
Base& *
{ 
public 

class 

DadosLogin 
{ 
public 
string 
Email 
{ 
get !
;! "
set# &
;& '
}( )
public 
bool 
FlagGerente 
{  !
get" %
;% &
set' *
;* +
}, -
public 
bool !
FlagGerenteFinanceiro )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
public 
string 
Nome 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
	Sobrenome 
{  !
get" %
;% &
set' *
;* +
}, -
} 
} �
QC:\projects\personal\prestasys\Unisul.PrestaSys.Web\Models\Home\ErrorViewModel.cs
	namespace 	
Unisul
 
. 
	PrestaSys 
. 
Web 
. 
Models %
.% &
Home& *
{ 
public 

class 
ErrorViewModel 
:  !
BaseViewModel" /
{ 
public 
string 
	RequestId 
{  !
get" %
;% &
set' *
;* +
}, -
public		 
bool		 
ShowRequestId		 !
=>		" $
!		% &
string		& ,
.		, -
IsNullOrEmpty		- :
(		: ;
	RequestId		; D
)		D E
;		E F
}

 
} �
RC:\projects\personal\prestasys\Unisul.PrestaSys.Web\Models\Login\LoginViewModel.cs
	namespace 	
Unisul
 
. 
	PrestaSys 
. 
Web 
. 
Models %
.% &
Login& +
{ 
public 

class 
LoginViewModel 
:  !
BaseViewModel" /
{ 
[ 	
Required	 
( 
ErrorMessage 
=  
$str! J
)J K
]K L
[		 	
RegularExpression			 
(		 
$str		 )
,		) *
ErrorMessage		+ 7
=		8 9
$str		: k
)		k l
]		l m
[

 	
Display

	 
(

 
Name

 
=

 
$str

  
)

  !
]

! "
public 
string 
Email 
{ 
get !
;! "
set# &
;& '
}( )
[ 	
Required	 
( 
ErrorMessage 
=  
$str! I
)I J
]J K
[ 	
DataType	 
( 
DataType 
. 
Password #
)# $
]$ %
[ 	
Display	 
( 
Name 
= 
$str 
)  
]  !
public 
string 
Senha 
{ 
get !
;! "
set# &
;& '
}( )
} 
} �
_C:\projects\personal\prestasys\Unisul.PrestaSys.Web\Models\Prestacoes\PrestacaoListViewModel.cs
	namespace 	
Unisul
 
. 
	PrestaSys 
. 
Web 
. 
Models %
.% &

Prestacoes& 0
{ 
public 

class "
PrestacaoListViewModel '
:( )
BaseViewModel* 7
{ 
public 
IEnumerable 
< 
PrestacaoViewModel -
>- .
PrestacoesList/ =
{> ?
get@ C
;C D
setE H
;H I
}J K
public

 
int

 
TotalRecords

 
{

  !
get

" %
;

% &
set

' *
;

* +
}

, -
public 
int 

PageNumber 
{ 
get  #
;# $
set% (
;( )
}* +
} 
} �1
[C:\projects\personal\prestasys\Unisul.PrestaSys.Web\Models\Prestacoes\PrestacaoViewModel.cs
	namespace

 	
Unisul


 
.

 
	PrestaSys

 
.

 
Web

 
.

 
Models

 %
.

% &

Prestacoes

& 0
{ 
public 

class 
PrestacaoViewModel #
:$ %
BaseViewModel& 3
{ 
public 
Usuario 
	Aprovador  
{! "
get# &
;& '
set( +
;+ ,
}- .
[ 	
Display	 
( 
Name 
= 
$str .
). /
]/ 0
public 
Usuario 
AprovadorFinanceiro *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
[ 	
Required	 
] 
public 
int !
AprovadorFinanceiroId 3
{4 5
get6 9
;9 :
set; >
;> ?
}@ A
[ 	
Required	 
] 
public 
int 
AprovadorId )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
[ 	
DataType	 
( 
DataType 
. 
Date 
)  
]  !
[ 	
DisplayFormat	 
( !
ApplyFormatInEditMode ,
=- .
true/ 3
,3 4
DataFormatString5 E
=F G
$strH X
)X Y
]Y Z
[ 	
Required	 
( 
ErrorMessage 
=  
$str! J
)J K
]K L
public 
DateTime 
Data 
{ 
get "
;" #
set$ '
;' (
}) *
public 
Usuario 
Emitente 
{  !
get" %
;% &
set' *
;* +
}, -
[ 	
Display	 
( 
Name 
= 
$str "
)" #
]# $
[ 	
Required	 
] 
public   
int   

EmitenteId   
{   
get    #
;  # $
set  % (
;  ( )
}  * +
public"" 
int"" 
Id"" 
{"" 
get"" 
;"" 
set""  
;""  !
}""" #
[$$ 	
Display$$	 
($$ 
Name$$ 
=$$ 
$str$$ 2
)$$2 3
]$$3 4
public%% 
	IFormFile%% 
ImagemComprovante%% *
{%%+ ,
get%%- 0
;%%0 1
set%%2 5
;%%5 6
}%%7 8
public'' 
string''  
ImagemComprovanteSrc'' *
{''+ ,
get''- 0
;''0 1
set''2 5
;''5 6
}''7 8
[)) 	
Required))	 
()) 
ErrorMessage)) 
=))  
$str))! W
)))W X
]))X Y
public** 
string** 
Justificativa** #
{**$ %
get**& )
;**) *
set**+ .
;**. /
}**0 1
[,, 	
Display,,	 
(,, 
Name,, 
=,, 
$str,, ?
),,? @
],,@ A
public-- 
string-- "
JustificativaAprovacao-- ,
{--- .
get--/ 2
;--2 3
set--4 7
;--7 8
}--9 :
[// 	
Display//	 
(// 
Name// 
=// 
$str// M
)//M N
]//N O
public00 
string00 ,
 JustificativaAprovacaoFinanceira00 6
{007 8
get009 <
;00< =
set00> A
;00A B
}00C D
public22 
PrestacaoStatus22 
Status22 %
{22& '
get22( +
;22+ ,
set22- 0
;220 1
}222 3
[44 	
Required44	 
]44 
[44 
Display44 
(44 
Name44  
=44! "
$str44# +
)44+ ,
]44, -
public44. 4
int445 8
StatusId449 A
{44B C
get44D G
;44G H
set44I L
;44L M
}44N O
public66 
PrestacaoTipo66 
Tipo66 !
{66" #
get66$ '
;66' (
set66) ,
;66, -
}66. /
[88 	
Required88	 
]88 
[88 
Display88 
(88 
Name88  
=88! "
$str88# )
)88) *
]88* +
public88, 2
int883 6
TipoId887 =
{88> ?
get88@ C
;88C D
set88E H
;88H I
}88J K
public:: 

SelectList:: #
TipoPrestacaoSelectList:: 1
{::2 3
get::4 7
;::7 8
set::9 <
;::< =
}::> ?
[<< 	
Required<<	 
(<< 
ErrorMessage<< 
=<<  
$str<<! L
)<<L M
]<<M N
[== 	
Display==	 
(== 
Name== 
=== 
$str== -
)==- .
]==. /
public>> 
string>> 
Titulo>> 
{>> 
get>> "
;>>" #
set>>$ '
;>>' (
}>>) *
[@@ 	
Required@@	 
(@@ 
ErrorMessage@@ 
=@@  
$str@@! K
)@@K L
]@@L M
[AA 	
DataTypeAA	 
(AA 
DataTypeAA 
.AA 
CurrencyAA #
)AA# $
]AA$ %
publicBB 
decimalBB 
ValorBB 
{BB 
getBB "
;BB" #
setBB$ '
;BB' (
}BB) *
publicDD 
boolDD 
ShouldLockPrestacaoDD '
=>DD( *
StatusDD+ 1
?DD1 2
.DD2 3
IdDD3 5
==DD6 8
(DD9 :
intDD: =
)DD= >
PrestacaoStatusEnumDD? R
.DDR S

FinalizadaDDS ]
;DD] ^
}EE 
}FF �
[C:\projects\personal\prestasys\Unisul.PrestaSys.Web\Models\Usuarios\UsuarioListViewModel.cs
	namespace 	
Unisul
 
. 
	PrestaSys 
. 
Web 
. 
Models %
.% &
Usuarios& .
{ 
public 

class  
UsuarioListViewModel %
:& '
BaseViewModel( 5
{ 
public 
IEnumerable 
< 
UsuarioViewModel +
>+ ,
UsuariosList- 9
{: ;
get< ?
;? @
setA D
;D E
}F G
public

 
int

 
TotalRecords

 
{

  !
get

" %
;

% &
set

' *
;

* +
}

, -
public 
int 

PageNumber 
{ 
get  #
;# $
set% (
;( )
}* +
} 
} �+
WC:\projects\personal\prestasys\Unisul.PrestaSys.Web\Models\Usuarios\UsuarioViewModel.cs
	namespace		 	
Unisul		
 
.		 
	PrestaSys		 
.		 
Web		 
.		 
Models		 %
.		% &
Usuarios		& .
{

 
public 

class 
UsuarioViewModel !
:" #
BaseViewModel$ 1
{ 
[ 	
RegularExpression	 
( 
$str )
,) *
ErrorMessage+ 7
=8 9
$str: `
)` a
]a b
[ 	
Required	 
( 
ErrorMessage 
=  
$str! J
)J K
]K L
[ 	
Display	 
( 
Name 
= 
$str  
)  !
]! "
public 
string 
Email 
{ 
get !
;! "
set# &
;& '
}( )
[ 	
Required	 
] 
[ 	
Display	 
( 
Name 
= 
$str $
)$ %
]% &
public 
bool 
FlagGerente 
{  !
get" %
;% &
set' *
;* +
}, -
[ 	
Required	 
] 
[ 	
Display	 
( 
Name 
= 
$str /
)/ 0
]0 1
public 
bool !
FlagGerenteFinanceiro )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
[ 	
Display	 
( 
Name 
= 
$str !
)! "
]" #
public$ *
Usuario+ 2
Gerente3 :
{; <
get= @
;@ A
setB E
;E F
}G H
[ 	
Display	 
( 
Name 
= 
$str ,
), -
]- .
public/ 5
Usuario6 =
GerenteFinanceiro> O
{P Q
getR U
;U V
setW Z
;Z [
}\ ]
[ 	
Required	 
] 
[ 	
Display	 
( 
Name 
= 
$str ,
), -
]- .
public   
int   
?   
GerenteFinanceiroId   '
{  ( )
get  * -
;  - .
set  / 2
;  2 3
}  4 5
public"" 

SelectList"" '
GerenteFinanceiroSelectList"" 5
{""6 7
get""8 ;
;""; <
set""= @
;""@ A
}""B C
[$$ 	
Required$$	 
]$$ 
[$$ 
Display$$ 
($$ 
Name$$  
=$$! "
$str$$# ,
)$$, -
]$$- .
public$$/ 5
int$$6 9
?$$9 :
	GerenteId$$; D
{$$E F
get$$G J
;$$J K
set$$L O
;$$O P
}$$Q R
public&& 

SelectList&& 
GerenteSelectList&& +
{&&, -
get&&. 1
;&&1 2
set&&3 6
;&&6 7
}&&8 9
public(( 
int(( 
Id(( 
{(( 
get(( 
;(( 
set((  
;((  !
}((" #
[** 	
Required**	 
(** 
ErrorMessage** 
=**  
$str**! H
)**H I
]**I J
public++ 
string++ 
Nome++ 
{++ 
get++  
;++  !
set++" %
;++% &
}++' (
public-- 
ICollection-- 
<-- 
	Prestacao-- $
>--$ %
PrestacaoAprovador--& 8
{--9 :
get--; >
;--> ?
set--@ C
;--C D
}--E F
public// 
ICollection// 
<// 
	Prestacao// $
>//$ %(
PrestacaoAprovadorFinanceiro//& B
{//C D
get//E H
;//H I
set//J M
;//M N
}//O P
public11 
ICollection11 
<11 
	Prestacao11 $
>11$ %
PrestacaoEmitente11& 7
{118 9
get11: =
;11= >
set11? B
;11B C
}11D E
[33 	
Required33	 
(33 
ErrorMessage33 
=33  
$str33! I
)33I J
]33J K
public44 
string44 
Senha44 
{44 
get44 !
;44! "
set44# &
;44& '
}44( )
public66 
bool66 %
ShouldDisableDeleteButton66 -
=>66. 0
PrestacaoAprovador661 C
!=66D F
null66G K
&&66L N
PrestacaoAprovador66O a
.66a b
Any66b e
(66e f
)66f g
||66h j(
PrestacaoAprovadorFinanceiro771 M
!=77N P
null77Q U
&&77V X(
PrestacaoAprovadorFinanceiro881 M
.88M N
Any88N Q
(88Q R
)88R S
;88S T
[:: 	
Required::	 
(:: 
ErrorMessage:: 
=::  
$str::! M
)::M N
]::N O
public;; 
string;; 
	Sobrenome;; 
{;;  !
get;;" %
;;;% &
set;;' *
;;;* +
};;, -
}<< 
}== �	
>C:\projects\personal\prestasys\Unisul.PrestaSys.Web\Program.cs
	namespace 	
Unisul
 
. 
	PrestaSys 
. 
Web 
{ 
public 

class 
Program 
{ 
public 
static 
IWebHostBuilder % 
CreateWebHostBuilder& :
(: ;
string; A
[A B
]B C
argsD H
)H I
{		 	
return

 
WebHost

 
.

  
CreateDefaultBuilder

 /
(

/ 0
args

0 4
)

4 5
. 

UseStartup 
< 
Startup #
># $
($ %
)% &
;& '
} 	
public 
static 
void 
Main 
(  
string  &
[& '
]' (
args) -
)- .
{ 	 
CreateWebHostBuilder  
(  !
args! %
)% &
.& '
Build' ,
(, -
)- .
.. /
Run/ 2
(2 3
)3 4
;4 5
} 	
} 
} �%
QC:\projects\personal\prestasys\Unisul.PrestaSys.Web\Services\ViewRenderService.cs
	namespace 	
Unisul
 
. 
	PrestaSys 
. 
Web 
. 
Services '
{ 
public 

	interface 
IViewRenderService '
{ 
Task 
< 
string 
> 
RenderToStringAsync (
(( )
string) /
viewName0 8
,8 9
object: @
modelA F
)F G
;G H
} 
public 

class 
ViewRenderService "
:# $
IViewRenderService% 7
{ 
private 
readonly 
IRazorViewEngine )
_razorViewEngine* :
;: ;
private 
readonly 
IServiceProvider )
_serviceProvider* :
;: ;
private 
readonly 
ITempDataProvider *
_tempDataProvider+ <
;< =
public 
ViewRenderService  
(  !
IRazorViewEngine 
razorViewEngine ,
,, -
ITempDataProvider 
tempDataProvider .
,. /
IServiceProvider 
serviceProvider ,
), -
{ 	
_razorViewEngine 
= 
razorViewEngine .
;. /
_tempDataProvider   
=   
tempDataProvider    0
;  0 1
_serviceProvider!! 
=!! 
serviceProvider!! .
;!!. /
}"" 	
public$$ 
async$$ 
Task$$ 
<$$ 
string$$  
>$$  !
RenderToStringAsync$$" 5
($$5 6
string$$6 <
viewName$$= E
,$$E F
object$$G M
model$$N S
)$$S T
{%% 	
var&& 
httpContext&& 
=&& 
new&& !
DefaultHttpContext&&" 4
{&&5 6
RequestServices&&6 E
=&&F G
_serviceProvider&&H X
}&&X Y
;&&Y Z
var'' 
actionContext'' 
='' 
new''  #
ActionContext''$ 1
(''1 2
httpContext''2 =
,''= >
new''? B
	RouteData''C L
(''L M
)''M N
,''N O
new''P S
ActionDescriptor''T d
(''d e
)''e f
)''f g
;''g h
using)) 
()) 
var)) 
sw)) 
=)) 
new)) 
StringWriter))  ,
()), -
)))- .
))). /
{** 
var++ 

viewResult++ 
=++  
_razorViewEngine++! 1
.++1 2
GetView++2 9
(++9 :
null++: >
,++> ?
viewName++@ H
,++H I
false++J O
)++O P
;++P Q
if-- 
(-- 

viewResult-- 
.-- 
View-- #
==--$ &
null--' +
)--+ ,
throw.. 
new.. !
ArgumentNullException.. 3
(..3 4
$"..4 6
{..6 7
viewName..7 ?
}..? @6
* não corresponde a nenhuma view existente..@ i
"..i j
)..j k
;..k l
var00 
viewDictionary00 "
=00# $
new11 
ViewDataDictionary11 *
(11* +
new22 &
EmptyModelMetadataProvider22  :
(22: ;
)22; <
,22< =
new33  
ModelStateDictionary33  4
(334 5
)335 6
)336 7
{44 
Model44 
=44  
model44! &
}44& '
;44' (
var66 
viewContext66 
=66  !
new66" %
ViewContext66& 1
(661 2
actionContext77 !
,77! "

viewResult88 
.88 
View88 #
,88# $
viewDictionary99 "
,99" #
new:: 
TempDataDictionary:: *
(::* +
actionContext::+ 8
.::8 9
HttpContext::9 D
,::D E
_tempDataProvider::F W
)::W X
,::X Y
sw;; 
,;; 
new<< 
HtmlHelperOptions<< )
(<<) *
)<<* +
)<<+ ,
;<<, -
await>> 

viewResult>>  
.>>  !
View>>! %
.>>% &
RenderAsync>>& 1
(>>1 2
viewContext>>2 =
)>>= >
;>>> ?
return?? 
sw?? 
.?? 
ToString?? "
(??" #
)??# $
;??$ %
}@@ 
}AA 	
}BB 
}CC �E
>C:\projects\personal\prestasys\Unisul.PrestaSys.Web\Startup.cs
	namespace 	
Unisul
 
. 
	PrestaSys 
. 
Web 
{ 
public 

class 
Startup 
{ 
public 
Startup 
( 
IConfiguration %
configuration& 3
)3 4
{ 	
Configuration 
= 
configuration )
;) *
} 	
public!! 
IConfiguration!! 
Configuration!! +
{!!, -
get!!. 1
;!!1 2
}!!3 4
public## 
void## 
	Configure## 
(## 
IApplicationBuilder## 1
app##2 5
,##5 6
IHostingEnvironment##7 J
env##K N
)##N O
{$$ 	
var%% 
cultureInfo%% 
=%% 
new%% !
CultureInfo%%" -
(%%- .
$str%%. 5
)%%5 6
{&& 
NumberFormat'' 
='' 
{''  
CurrencySymbol''! /
=''0 1
$str''2 6
}''7 8
}(( 
;(( 
Thread** 
.** 
CurrentThread**  
.**  !
CurrentCulture**! /
=**0 1
cultureInfo**2 =
;**= >
Thread++ 
.++ 
CurrentThread++  
.++  !
CurrentUICulture++! 1
=++2 3
cultureInfo++4 ?
;++? @
var-- 
supportedCultures-- !
=--" #
new--$ '
[--' (
]--( )
{.. 
new// 
CultureInfo// 
(//  
$str//  '
)//' (
}00 
;00 
app22 
.22 "
UseRequestLocalization22 &
(22& '
new22' *&
RequestLocalizationOptions22+ E
{33 !
DefaultRequestCulture44 %
=44& '
new44( +
RequestCulture44, :
(44: ;
$str44; B
)44B C
,44C D
SupportedCultures55 !
=55" #
supportedCultures55$ 5
,555 6
SupportedUICultures66 #
=66$ %
supportedCultures66& 7
}77 
)77 
;77 
if99 
(99 
env99 
.99 
IsDevelopment99 !
(99! "
)99" #
)99# $
app:: 
.:: %
UseDeveloperExceptionPage:: -
(::- .
)::. /
;::/ 0
else;; 
app<< 
.<< 
UseExceptionHandler<< '
(<<' (
$str<<( 5
)<<5 6
;<<6 7
app>> 
.>> 
UseStaticFiles>> 
(>> 
)>>  
;>>  !
app?? 
.?? 
UseCookiePolicy?? 
(??  
)??  !
;??! "
appAA 
.AA 
UseAuthenticationAA !
(AA! "
)AA" #
;AA# $
appCC 
.CC 
UseMvcCC 
(CC 
routesCC 
=>CC  
{DD 
routesEE 
.EE 
MapRouteEE 
(EE  
$strFF 
,FF 
$strGG =
)GG= >
;GG> ?
}HH 
)HH 
;HH 
}II 	
publicKK 
voidKK 
ConfigureServicesKK %
(KK% &
IServiceCollectionKK& 8
servicesKK9 A
)KKA B
{LL 	
servicesMM 
.MM 
	ConfigureMM 
<MM 
CookiePolicyOptionsMM 2
>MM2 3
(MM3 4
optionsMM4 ;
=>MM< >
{NN 
optionsOO 
.OO 
CheckConsentNeededOO *
=OO+ ,
contextOO- 4
=>OO5 7
trueOO8 <
;OO< =
optionsPP 
.PP !
MinimumSameSitePolicyPP -
=PP. /
SameSiteModePP0 <
.PP< =
NonePP= A
;PPA B
}QQ 
)QQ 
;QQ 
servicesSS 
.SS 
AddMvcSS 
(SS 
)SS 
.SS #
SetCompatibilityVersionSS 5
(SS5 6 
CompatibilityVersionSS6 J
.SSJ K
Version_2_2SSK V
)SSV W
;SSW X
servicesTT 
.TT 
AddAutoMapperTT "
(TT" #
)TT# $
;TT$ %
servicesVV 
.VV 
AddAuthenticationVV &
(VV& '
optionsVV' .
=>VV/ 1
{WW 
optionsXX 
.XX 
DefaultSignInSchemeXX +
=XX, -(
CookieAuthenticationDefaultsXX. J
.XXJ K 
AuthenticationSchemeXXK _
;XX_ `
optionsYY 
.YY %
DefaultAuthenticateSchemeYY 1
=YY2 3(
CookieAuthenticationDefaultsYY4 P
.YYP Q 
AuthenticationSchemeYYQ e
;YYe f
optionsZZ 
.ZZ "
DefaultChallengeSchemeZZ .
=ZZ/ 0(
CookieAuthenticationDefaultsZZ1 M
.ZZM N 
AuthenticationSchemeZZN b
;ZZb c
}[[ 
)[[ 
.[[ 
	AddCookie[[ 
([[ 
options[[  
=>[[! #
{\\ 
options]] 
.]] 
	LoginPath]] !
=]]" #
new]]$ '

PathString]]( 2
(]]2 3
$str]]3 ;
)]]; <
;]]< =
options^^ 
.^^ 
ExpireTimeSpan^^ &
=^^' (
TimeSpan^^) 1
.^^1 2
FromMinutes^^2 =
(^^= >
$num^^> A
)^^A B
;^^B C
}__ 
)__ 
;__ 
servicesaa 
.aa 
AddMvcaa 
(aa 
)aa 
.aa  
AddRazorPagesOptionsaa 2
(aa2 3
optionsaa3 :
=>aa; =
{bb 
optionscc 
.cc 
Conventionscc #
.cc# $
AuthorizeFoldercc$ 3
(cc3 4
$strcc4 7
)cc7 8
;cc8 9
optionsdd 
.dd 
Conventionsdd #
.dd# $ 
AllowAnonymousToPagedd$ 8
(dd8 9
$strdd9 A
)ddA B
;ddB C
}ee 
)ee 
;ee 
serviceshh 
.hh 
	Configurehh 
<hh 
EmailSettingshh ,
>hh, -
(hh- .
Configurationhh. ;
.hh; <

GetSectionhh< F
(hhF G
$strhhG V
)hhV W
)hhW X
;hhX Y
servicesii 
.ii 
	Configureii 
<ii 
JsReportSettingsii /
>ii/ 0
(ii0 1
Configurationii1 >
.ii> ?

GetSectionii? I
(iiI J
$striiJ \
)ii\ ]
)ii] ^
;ii^ _
serviceskk 
.kk 
AddDbContextkk !
<kk! "
PrestaSysDbContextkk" 4
>kk4 5
(kk5 6
optionskk6 =
=>kk> @
optionsll 
.ll 
UseSqlServerll $
(ll$ %
Configurationll% 2
.ll2 3
GetConnectionStringll3 F
(llF G
$strllG T
)llT U
)llU V
)llV W
;llW X
servicesnn 
.nn 
	AddScopednn 
<nn 
IPrestaSysDbContextnn 2
>nn2 3
(nn3 4
providernn4 <
=>nn= ?
providernn@ H
.nnH I

GetServicennI S
<nnS T
PrestaSysDbContextnnT f
>nnf g
(nng h
)nnh i
)nni j
;nnj k
servicesoo 
.oo 
AddTransientoo !
<oo! " 
IPrestacaoRepositoryoo" 6
,oo6 7
PrestacaoRepositoryoo8 K
>ooK L
(ooL M
)ooM N
;ooN O
servicespp 
.pp 
AddTransientpp !
<pp! "
IUsuarioRepositorypp" 4
,pp4 5
UsuarioRepositorypp6 G
>ppG H
(ppH I
)ppI J
;ppJ K
servicesqq 
.qq 
AddTransientqq !
<qq! "
IUsuarioServiceqq" 1
,qq1 2
UsuarioServiceqq3 A
>qqA B
(qqB C
)qqC D
;qqD E
servicesrr 
.rr 
AddTransientrr !
<rr! "
IPrestacaoServicerr" 3
,rr3 4
PrestacaoServicerr5 E
>rrE F
(rrF G
)rrG H
;rrH I
servicestt 
.tt 
AddTransienttt !
<tt! "
IViewRenderServicett" 4
,tt4 5
ViewRenderServicett6 G
>ttG H
(ttH I
)ttI J
;ttJ K
servicesuu 
.uu 
AddTransientuu !
<uu! "
IEmailHelperuu" .
,uu. /
EmailHelperuu0 ;
>uu; <
(uu< =
)uu= >
;uu> ?
}vv 	
}ww 
}xx 