˜8
NC:\projects\personal\prestasys\Unisul.PrestaSys.Dominio\Helpers\EmailHelper.cs
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
 
Dominio

 "
.

" #
Helpers

# *
{ 
public 

	interface 
IEmailHelper !
{ 
bool 
EnviarEmail 
( 
	Prestacao "
	prestacao# ,
,, -
PrestacaoStatusEnum. A
statusAtualB M
,M N
stringO U
emailToV ]
)] ^
;^ _
} 
public 

class 
EmailHelper 
: 
IEmailHelper +
{ 
private 
readonly 
EmailSettings &
_emailSettings' 5
;5 6
private 
readonly 
IHostingEnvironment ,
_environment- 9
;9 :
public 
EmailHelper 
( 
IOptions #
<# $
EmailSettings$ 1
>1 2
emailSettings3 @
,@ A
IHostingEnvironmentB U
environmentV a
)a b
{ 	
_emailSettings 
= 
emailSettings *
.* +
Value+ 0
;0 1
_environment 
= 
environment &
;& '
} 	
public 
bool 
EnviarEmail 
(  
	Prestacao  )
	prestacao* 3
,3 4
PrestacaoStatusEnum5 H
statusAtualI T
,T U
stringV \
emailTo] d
)d e
{ 	
try 
{   
var!! 
mail!! 
=!! 
new!! 
MailMessage!! *
{"" 
From## 
=## 
new## 
MailAddress## *
(##* +
_emailSettings##+ 9
.##9 :
	FromEmail##: C
,##C D
$str##E P
)##P Q
}$$ 
;$$ 
mail&& 
.&& 
To&& 
.&& 
Add&& 
(&& 
new&& 
MailAddress&&  +
(&&+ ,
emailTo&&, 3
)&&3 4
)&&4 5
;&&5 6
mail'' 
.'' 
Subject'' 
='' 
$str'' C
+''D E
	prestacao''F O
.''O P
Titulo''P V
;''V W
mail(( 
.(( 
Body(( 
=(( 
GetEmailBody(( (
(((( )
	prestacao(() 2
,((2 3
statusAtual((4 ?
)((? @
;((@ A
mail)) 
.)) 

IsBodyHtml)) 
=))  !
true))" &
;))& '
mail** 
.** 
Priority** 
=** 
MailPriority**  ,
.**, -
High**- 1
;**1 2
using,, 
(,, 
var,, 
smtp,, 
=,,  !
new,," %

SmtpClient,,& 0
(,,0 1
_emailSettings,,1 ?
.,,? @
PrimaryDomain,,@ M
,,,M N
_emailSettings,,O ]
.,,] ^
PrimaryPort,,^ i
),,i j
),,j k
{-- 
smtp.. 
... 
Credentials.. $
=..% &
new// 
NetworkCredential// -
(//- .
_emailSettings//. <
.//< =
UsernameEmail//= J
,//J K
_emailSettings//L Z
.//Z [
UsernamePassword//[ k
)//k l
;//l m
smtp11 
.11 
	EnableSsl11 "
=11# $
true11% )
;11) *
if33 
(33 
!33 
_environment33 %
.33% &
IsDevelopment33& 3
(333 4
)334 5
)335 6
smtp44 
.44 
Send44 !
(44! "
mail44" &
)44& '
;44' (
return66 
true66 
;66  
}77 
}88 
catch99 
(99 
	Exception99 
)99 
{:: 
return;; 
false;; 
;;; 
}<< 
}== 	
private?? 
static?? 
string?? 
GetEmailBody?? *
(??* +
	Prestacao??+ 4
	prestacao??5 >
,??> ?
PrestacaoStatusEnum??@ S
statusAtual??T _
)??_ `
{@@ 	
varAA 
textAA 
=AA 
GetMessageBodyTextAA )
(AA) *
)AA* +
;AA+ ,
textBB 
=BB 
textBB 
.BB 
ReplaceBB 
(BB  
$strBB  ,
,BB, -
	prestacaoBB. 7
.BB7 8
TituloBB8 >
)BB> ?
;BB? @
switchDD 
(DD 
statusAtualDD 
)DD  
{EE 
caseFF 
PrestacaoStatusEnumFF (
.FF( )"
EmAprovacaoOperacionalFF) ?
:FF? @
textGG 
=GG 
textGG 
.GG  
ReplaceGG  '
(GG' (
$strGG( 4
,GG4 5
$strGG6 f
)GGf g
;GGg h
textHH 
=HH 
textHH 
.HH  
ReplaceHH  '
(HH' (
$strHH( 9
,HH9 :
$strII w
)IIw x
;IIx y
breakJJ 
;JJ 
caseKK 
PrestacaoStatusEnumKK (
.KK( )!
EmAprovacaoFinanceiraKK) >
:KK> ?
textLL 
=LL 
textLL 
.LL  
ReplaceLL  '
(LL' (
$strLL( 4
,LL4 5
$strLL6 e
)LLe f
;LLf g
textMM 
=MM 
textMM 
.MM  
ReplaceMM  '
(MM' (
$strMM( 9
,MM9 :
$str	NN Ç
)
NNÇ É
;
NNÉ Ñ
breakOO 
;OO 
casePP 
PrestacaoStatusEnumPP (
.PP( )
	RejeitadaPP) 2
:PP2 3
textQQ 
=QQ 
textQQ 
.QQ  
ReplaceQQ  '
(QQ' (
$strQQ( 4
,QQ4 5
$strQQ6 A
)QQA B
;QQB C
textRR 
=RR 
textRR 
.RR  
ReplaceRR  '
(RR' (
$strRR( 9
,RR9 :
$strSS Z
)SSZ [
;SS[ \
breakTT 
;TT 
caseUU 
PrestacaoStatusEnumUU (
.UU( )

FinalizadaUU) 3
:UU3 4
textVV 
=VV 
textVV 
.VV  
ReplaceVV  '
(VV' (
$strVV( 4
,VV4 5
$strVV6 B
)VVB C
;VVC D
textWW 
=WW 
textWW 
.WW  
ReplaceWW  '
(WW' (
$strWW( 9
,WW9 :
$strWW; [
)WW[ \
;WW\ ]
breakXX 
;XX 
}YY 
return[[ 
text[[ 
;[[ 
}\\ 	
private^^ 
static^^ 
string^^ 
GetMessageBodyText^^ 0
(^^0 1
)^^1 2
{__ 	
return`` 
$str`c 6
;cc6 7
}dd 	
}ee 
}ff Æà
_C:\projects\personal\prestasys\Unisul.PrestaSys.Dominio\Servicos\Prestacoes\PrestacaoService.cs
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
 
Dominio

 "
.

" #
Servicos

# +
.

+ ,

Prestacoes

, 6
{ 
public 

	interface 
IPrestacaoService &
{ 
int 
AprovarPrestacao 
( 
int  
prestacaoId! ,
,, -
string. 4
justificativa5 B
,B C
PrestacaoStatusEnumD W
tipoAprovacaoX e
)e f
;f g
int 
Create 
( 
	Prestacao 
	prestacao &
)& '
;' (
int 
Delete 
( 
int 
id 
) 
; 
bool 
Exists 
( 
int 
id 
) 
;  
IIncludableQueryable 
< 
	Prestacao &
,& '
PrestacaoTipo( 5
>5 6
GetAll7 =
(= >
)> ?
;? @

IQueryable 
< 
	Prestacao 
> 
GetAllByEmitenteId 0
(0 1
int1 4

emitenteId5 ?
)? @
;@ A

IQueryable 
< 
	Prestacao 
> 
GetAllParaAprovacao 1
(1 2
int2 5
aprovadorId6 A
,A B
PrestacaoStatusEnumC V
tipoAprovacaoW d
)d e
;e f
	Prestacao 
GetById 
( 
int 
id  
)  !
;! "
int 
RejeitarPrestacao 
( 
int !
prestacaoId" -
,- .
string/ 5
justificativa6 C
,C D
PrestacaoStatusEnumE X
tipoAprovacaoY f
)f g
;g h
int 
Update 
( 
	Prestacao 
	prestacao &
)& '
;' (

IQueryable 
< 
PrestacaoTipo  
>  ! 
GetAllPrestacaoTipos" 6
(6 7
)7 8
;8 9
} 
public 

class 
PrestacaoService !
:" #
IPrestacaoService$ 5
{ 
private 
readonly  
IPrestacaoRepository -
_repository. 9
;9 :
private 
readonly 
IEmailHelper %
_emailHelper& 2
;2 3
private 
readonly 
IUsuarioService (
_usuarioService) 8
;8 9
public!! 
PrestacaoService!! 
(!!   
IPrestacaoRepository!!  4

repository!!5 ?
,!!? @
IEmailHelper!!A M
emailHelper!!N Y
,!!Y Z
IUsuarioService!![ j
usuarioService!!k y
)!!y z
{"" 	
_repository## 
=## 

repository## $
;##$ %
_emailHelper$$ 
=$$ 
emailHelper$$ &
;$$& '
_usuarioService%% 
=%% 
usuarioService%% ,
;%%, -
}&& 	
public(( 
int(( 
AprovarPrestacao(( #
(((# $
int(($ '
prestacaoId((( 3
,((3 4
string((5 ;
justificativa((< I
,((I J
PrestacaoStatusEnum((K ^
tipoAprovacao((_ l
)((l m
{)) 	
	Prestacao** 
	prestacao** 
;**  
switch,, 
(,, 
tipoAprovacao,, !
),,! "
{-- 
case.. 
PrestacaoStatusEnum.. (
...( )"
EmAprovacaoOperacional..) ?
:..? @
	prestacao// 
=// 
_repository//  +
.//+ ,
GetById//, 3
(//3 4
prestacaoId//4 ?
)//? @
;//@ A
	prestacao00 
.00 
StatusId00 &
=00' (
(00) *
int00* -
)00- .
PrestacaoStatusEnum00/ B
.00B C!
EmAprovacaoFinanceira00C X
;00X Y
	prestacao11 
.11 "
JustificativaAprovacao11 4
=115 6
justificativa117 D
;11D E
break22 
;22 
case44 
PrestacaoStatusEnum44 (
.44( )!
EmAprovacaoFinanceira44) >
:44> ?
	prestacao55 
=55 
_repository55  +
.55+ ,
GetById55, 3
(553 4
prestacaoId554 ?
)55? @
;55@ A
	prestacao66 
.66 
StatusId66 &
=66' (
(66) *
int66* -
)66- .
PrestacaoStatusEnum66/ B
.66B C

Finalizada66C M
;66M N
	prestacao77 
.77 ,
 JustificativaAprovacaoFinanceira77 >
=77? @
justificativa77A N
;77N O
break88 
;88 
case99 
PrestacaoStatusEnum99 (
.99( )

Finalizada99) 3
:993 4
	prestacao:: 
=:: 
_repository::  +
.::+ ,
GetById::, 3
(::3 4
prestacaoId::4 ?
)::? @
;::@ A
break;; 
;;; 
case<< 
PrestacaoStatusEnum<< (
.<<( )
	Rejeitada<<) 2
:<<2 3
	prestacao== 
=== 
_repository==  +
.==+ ,
GetById==, 3
(==3 4
prestacaoId==4 ?
)==? @
;==@ A
break>> 
;>> 
default?? 
:?? 
throw@@ 
new@@ '
ArgumentOutOfRangeException@@ 9
(@@9 :
nameof@@: @
(@@@ A
tipoAprovacao@@A N
)@@N O
,@@O P
tipoAprovacao@@Q ^
,@@^ _
null@@` d
)@@d e
;@@e f
}AA 
varCC 
emailToCC 
=CC 

GetEmailToCC $
(CC$ %
	prestacaoCC% .
,CC. /
(CC0 1
PrestacaoStatusEnumCC1 D
)CCD E
	prestacaoCCE N
.CCN O
StatusIdCCO W
)CCW X
;CCX Y
_emailHelperDD 
.DD 
EnviarEmailDD $
(DD$ %
	prestacaoDD% .
,DD. /
(DD0 1
PrestacaoStatusEnumDD1 D
)DDD E
	prestacaoDDF O
.DDO P
StatusIdDDP X
,DDX Y
emailToDDZ a
)DDa b
;DDb c
returnEE 
_repositoryEE 
.EE 
UpdateEE %
(EE% &
	prestacaoEE& /
)EE/ 0
;EE0 1
}FF 	
publicHH 
intHH 
CreateHH 
(HH 
	PrestacaoHH #
	prestacaoHH$ -
)HH- .
{II 	
varJJ 
emailToJJ 
=JJ 

GetEmailToJJ $
(JJ$ %
	prestacaoJJ% .
,JJ. /
PrestacaoStatusEnumJJ0 C
.JJC D"
EmAprovacaoOperacionalJJD Z
)JJZ [
;JJ[ \
_emailHelperKK 
.KK 
EnviarEmailKK $
(KK$ %
	prestacaoKK% .
,KK. /
PrestacaoStatusEnumKK0 C
.KKC D"
EmAprovacaoOperacionalKKD Z
,KKZ [
emailToKK\ c
)KKc d
;KKd e
returnLL 
_repositoryLL 
.LL 
CreateLL %
(LL% &
	prestacaoLL& /
)LL/ 0
;LL0 1
}MM 	
publicOO 
intOO 
DeleteOO 
(OO 
intOO 
idOO  
)OO  !
{PP 	
returnQQ 
_repositoryQQ 
.QQ 
DeleteQQ %
(QQ% &
idQQ& (
)QQ( )
;QQ) *
}RR 	
publicTT 
boolTT 
ExistsTT 
(TT 
intTT 
idTT !
)TT! "
{UU 	
returnVV 
_repositoryVV 
.VV 
ExistsVV %
(VV% &
idVV& (
)VV( )
;VV) *
}WW 	
publicYY  
IIncludableQueryableYY #
<YY# $
	PrestacaoYY$ -
,YY- .
PrestacaoTipoYY/ <
>YY< =
GetAllYY> D
(YYD E
)YYE F
{ZZ 	
return[[ 
_repository[[ 
.[[ 
GetAll[[ %
([[% &
)[[& '
;[[' (
}\\ 	
public^^ 

IQueryable^^ 
<^^ 
	Prestacao^^ #
>^^# $
GetAllByEmitenteId^^% 7
(^^7 8
int^^8 ;

emitenteId^^< F
)^^F G
{__ 	
return`` 
_repository`` 
.`` 
GetAll`` %
(``% &
)``& '
.``' (
Where``( -
(``- .
pr``. 0
=>``1 3
pr``4 6
.``6 7

EmitenteId``7 A
==``B D

emitenteId``E O
)``O P
;``P Q
}aa 	
publiccc 

IQueryablecc 
<cc 
	Prestacaocc #
>cc# $
GetAllParaAprovacaocc% 8
(cc8 9
intcc9 <
aprovadorIdcc= H
,ccH I
PrestacaoStatusEnumccJ ]
tipoAprovacaocc^ k
)cck l
{dd 	
ifee 
(ee 
tipoAprovacaoee 
==ee  
PrestacaoStatusEnumee! 4
.ee4 5"
EmAprovacaoOperacionalee5 K
)eeK L
returnff 
_repositoryff "
.ff" #
GetAllff# )
(ff) *
)ff* +
.ff+ ,
Whereff, 1
(ff1 2
prff2 4
=>ff5 7
prgg 
.gg 
AprovadorIdgg "
==gg# %
aprovadorIdgg& 1
&&gg2 4
prhh 
.hh 
StatusIdhh 
==hh  "
(hh# $
inthh$ '
)hh' (
PrestacaoStatusEnumhh) <
.hh< ="
EmAprovacaoOperacionalhh= S
)hhS T
;hhT U
ifjj 
(jj 
tipoAprovacaojj 
==jj  
PrestacaoStatusEnumjj! 4
.jj4 5!
EmAprovacaoFinanceirajj5 J
)jjJ K
returnkk 
_repositorykk "
.kk" #
GetAllkk# )
(kk) *
)kk* +
.kk+ ,
Wherekk, 1
(kk1 2
prkk2 4
=>kk5 7
prll 
.ll !
AprovadorFinanceiroIdll ,
==ll- /
aprovadorIdll0 ;
&&ll< >
prmm 
.mm 
StatusIdmm 
==mm  "
(mm# $
intmm$ '
)mm' (
PrestacaoStatusEnummm) <
.mm< =!
EmAprovacaoFinanceiramm= R
)mmR S
;mmS T
throwoo 
newoo !
NotSupportedExceptionoo +
(oo+ ,
)oo, -
;oo- .
}pp 	
publicrr 
	Prestacaorr 
GetByIdrr  
(rr  !
intrr! $
idrr% '
)rr' (
{ss 	
returntt 
_repositorytt 
.tt 
GetByIdtt &
(tt& '
idtt' )
)tt) *
;tt* +
}uu 	
publicww 
intww 
RejeitarPrestacaoww $
(ww$ %
intww% (
prestacaoIdww) 4
,ww4 5
stringww6 <
justificativaww= J
,wwJ K
PrestacaoStatusEnumwwL _
tipoAprovacaoww` m
)wwm n
{xx 	
	Prestacaoyy 
	prestacaoyy 
;yy  
switch{{ 
({{ 
tipoAprovacao{{ !
){{! "
{|| 
case}} 
PrestacaoStatusEnum}} (
.}}( )"
EmAprovacaoOperacional}}) ?
:}}? @
	prestacao~~ 
=~~ 
_repository~~  +
.~~+ ,
GetById~~, 3
(~~3 4
prestacaoId~~4 ?
)~~? @
;~~@ A
	prestacao 
. 
StatusId &
=' (
() *
int* -
)- .
PrestacaoStatusEnum/ B
.B C
	RejeitadaC L
;L M
	prestacao
ÄÄ 
.
ÄÄ $
JustificativaAprovacao
ÄÄ 4
=
ÄÄ5 6
justificativa
ÄÄ7 D
;
ÄÄD E
break
ÅÅ 
;
ÅÅ 
case
ÉÉ !
PrestacaoStatusEnum
ÉÉ (
.
ÉÉ( )#
EmAprovacaoFinanceira
ÉÉ) >
:
ÉÉ> ?
	prestacao
ÑÑ 
=
ÑÑ 
_repository
ÑÑ  +
.
ÑÑ+ ,
GetById
ÑÑ, 3
(
ÑÑ3 4
prestacaoId
ÑÑ4 ?
)
ÑÑ? @
;
ÑÑ@ A
	prestacao
ÖÖ 
.
ÖÖ 
StatusId
ÖÖ &
=
ÖÖ' (
(
ÖÖ) *
int
ÖÖ* -
)
ÖÖ- .!
PrestacaoStatusEnum
ÖÖ/ B
.
ÖÖB C
	Rejeitada
ÖÖC L
;
ÖÖL M
	prestacao
ÜÜ 
.
ÜÜ .
 JustificativaAprovacaoFinanceira
ÜÜ >
=
ÜÜ? @
justificativa
ÜÜA N
;
ÜÜN O
break
áá 
;
áá 
case
àà !
PrestacaoStatusEnum
àà (
.
àà( )

Finalizada
àà) 3
:
àà3 4
	prestacao
ââ 
=
ââ 
_repository
ââ  +
.
ââ+ ,
GetById
ââ, 3
(
ââ3 4
prestacaoId
ââ4 ?
)
ââ? @
;
ââ@ A
break
ää 
;
ää 
case
ãã !
PrestacaoStatusEnum
ãã (
.
ãã( )
	Rejeitada
ãã) 2
:
ãã2 3
	prestacao
åå 
=
åå 
_repository
åå  +
.
åå+ ,
GetById
åå, 3
(
åå3 4
prestacaoId
åå4 ?
)
åå? @
;
åå@ A
break
çç 
;
çç 
default
éé 
:
éé 
throw
èè 
new
èè )
ArgumentOutOfRangeException
èè 9
(
èè9 :
nameof
èè: @
(
èè@ A
tipoAprovacao
èèA N
)
èèN O
,
èèO P
tipoAprovacao
èèQ ^
,
èè^ _
null
èè` d
)
èèd e
;
èèe f
}
êê 
var
íí 
emailTo
íí 
=
íí 

GetEmailTo
íí $
(
íí$ %
	prestacao
íí% .
,
íí. /
(
íí0 1!
PrestacaoStatusEnum
íí1 D
)
ííD E
	prestacao
ííE N
.
ííN O
StatusId
ííO W
)
ííW X
;
ííX Y
_emailHelper
ìì 
.
ìì 
EnviarEmail
ìì $
(
ìì$ %
	prestacao
ìì% .
,
ìì. /
(
ìì0 1!
PrestacaoStatusEnum
ìì1 D
)
ììD E
	prestacao
ììE N
.
ììN O
StatusId
ììO W
,
ììW X
emailTo
ììY `
)
ìì` a
;
ììa b
return
îî 
_repository
îî 
.
îî 
Update
îî %
(
îî% &
	prestacao
îî& /
)
îî/ 0
;
îî0 1
}
ïï 	
public
óó 
int
óó 
Update
óó 
(
óó 
	Prestacao
óó #
	prestacao
óó$ -
)
óó- .
{
òò 	
return
ôô 
_repository
ôô 
.
ôô 
Update
ôô %
(
ôô% &
	prestacao
ôô& /
)
ôô/ 0
;
ôô0 1
}
öö 	
public
úú 

IQueryable
úú 
<
úú 
PrestacaoTipo
úú '
>
úú' ("
GetAllPrestacaoTipos
úú) =
(
úú= >
)
úú> ?
{
ùù 	
return
ûû 
_repository
ûû 
.
ûû "
GetAllPrestacaoTipos
ûû 3
(
ûû3 4
)
ûû4 5
;
ûû5 6
}
üü 	
private
°° 
string
°° 

GetEmailTo
°° !
(
°°! "
	Prestacao
°°" +
	prestacao
°°, 5
,
°°5 6!
PrestacaoStatusEnum
°°7 J
statusAtual
°°K V
)
°°V W
{
¢¢ 	
switch
££ 
(
££ 
statusAtual
££ 
)
££  
{
§§ 
case
•• !
PrestacaoStatusEnum
•• (
.
••( )$
EmAprovacaoOperacional
••) ?
:
••? @
return
¶¶ 
_usuarioService
¶¶ *
.
¶¶* +!
GetUsuarioEmailById
¶¶+ >
(
¶¶> ?
	prestacao
¶¶? H
.
¶¶H I
AprovadorId
¶¶I T
)
¶¶T U
;
¶¶U V
case
ßß !
PrestacaoStatusEnum
ßß (
.
ßß( )#
EmAprovacaoFinanceira
ßß) >
:
ßß> ?
return
®® 
_usuarioService
®® *
.
®®* +!
GetUsuarioEmailById
®®+ >
(
®®> ?
	prestacao
®®? H
.
®®H I#
AprovadorFinanceiroId
®®I ^
)
®®^ _
;
®®_ `
case
©© !
PrestacaoStatusEnum
©© (
.
©©( )
	Rejeitada
©©) 2
:
©©2 3
case
™™ !
PrestacaoStatusEnum
™™ (
.
™™( )

Finalizada
™™) 3
:
™™3 4
return
´´ 
_usuarioService
´´ *
.
´´* +!
GetUsuarioEmailById
´´+ >
(
´´> ?
	prestacao
´´? H
.
´´H I

EmitenteId
´´I S
)
´´S T
;
´´T U
}
¨¨ 
return
ÆÆ 
string
ÆÆ 
.
ÆÆ 
Empty
ÆÆ 
;
ÆÆ  
}
ØØ 	
}
∞∞ 
}±± Ì:
[C:\projects\personal\prestasys\Unisul.PrestaSys.Dominio\Servicos\Usuarios\UsuarioService.cs
	namespace 	
Unisul
 
. 
	PrestaSys 
. 
Dominio "
." #
Servicos# +
.+ ,
Usuarios, 4
{		 
public

 

	interface

 
IUsuarioService

 $
{ 
int 
Create 
( 
Usuario 
usuario "
)" #
;# $
int 
Delete 
( 
int 
id 
) 
; 
bool 
Exists 
( 
int 
id 
) 
;  
IIncludableQueryable 
< 
Usuario $
,$ %
ICollection& 1
<1 2
	Prestacao2 ;
>; <
>< =
GetAll> D
(D E
)E F
;F G

IQueryable 
< 
Usuario 
> 
GetAllGerentes *
(* +
)+ ,
;, -

IQueryable 
< 
Usuario 
> %
GetAllGerentesFinanceiros 5
(5 6
)6 7
;7 8
Usuario 
GetById 
( 
int 
id 
) 
;  
Usuario 
GetUsuarioByEmail !
(! "
string" (
email) .
). /
;/ 0
Usuario %
GetUsuarioByEmailAndSenha )
() *
string* 0
email1 6
,6 7
string8 >
senha? D
)D E
;E F
void 
Update 
( 
Usuario 
usuario #
)# $
;$ %
string 
GetUsuarioEmailById "
(" #
int# &
id' )
)) *
;* +
} 
public 

class 
UsuarioService 
:  !
IUsuarioService" 1
{ 
private 
readonly 
IUsuarioRepository +
_repository, 7
;7 8
public 
UsuarioService 
( 
IUsuarioRepository 0

repository1 ;
); <
{ 	
_repository 
= 

repository $
;$ %
}   	
public"" 
int"" 
Create"" 
("" 
Usuario"" !
usuario""" )
)"") *
{## 	
return$$ 
_repository$$ 
.$$ 
Create$$ %
($$% &
usuario$$& -
)$$- .
;$$. /
}%% 	
public'' 
int'' 
Delete'' 
('' 
int'' 
id''  
)''  !
{(( 	
return)) 
_repository)) 
.)) 
Delete)) %
())% &
id))& (
)))( )
;))) *
}** 	
public,, 
bool,, 
Exists,, 
(,, 
int,, 
id,, !
),,! "
{-- 	
return.. 
_repository.. 
... 
Exists.. %
(..% &
id..& (
)..( )
;..) *
}// 	
public11  
IIncludableQueryable11 #
<11# $
Usuario11$ +
,11+ ,
ICollection11- 8
<118 9
	Prestacao119 B
>11B C
>11C D
GetAll11E K
(11K L
)11L M
{22 	
return33 
_repository33 
.33 
GetAll33 %
(33% &
)33& '
;33' (
}44 	
public66 

IQueryable66 
<66 
Usuario66 !
>66! "
GetAllGerentes66# 1
(661 2
)662 3
{77 	
return88 
_repository88 
.88 
GetAll88 %
(88% &
)88& '
.88' (
Where88( -
(88- .
x88. /
=>880 2
x883 4
.884 5
FlagGerente885 @
)88@ A
;88A B
}99 	
public;; 

IQueryable;; 
<;; 
Usuario;; !
>;;! "%
GetAllGerentesFinanceiros;;# <
(;;< =
);;= >
{<< 	
return>> 
_repository>> 
.>> 
GetAll>> %
(>>% &
)>>& '
.>>' (
Where>>( -
(>>- .
x>>. /
=>>>0 2
x>>3 4
.>>4 5!
FlagGerenteFinanceiro>>5 J
)>>J K
;>>K L
}?? 	
publicAA 
UsuarioAA 
GetByIdAA 
(AA 
intAA "
idAA# %
)AA% &
{BB 	
returnCC 
_repositoryCC 
.CC 
GetByIdCC &
(CC& '
idCC' )
)CC) *
;CC* +
}DD 	
publicFF 
stringFF 
GetUsuarioEmailByIdFF )
(FF) *
intFF* -
idFF. 0
)FF0 1
{GG 	
returnHH 
_repositoryHH 
.HH 
GetByIdHH &
(HH& '
idHH' )
)HH) *
.HH* +
EmailHH+ 0
;HH0 1
}II 	
publicKK 
UsuarioKK 
GetUsuarioByEmailKK (
(KK( )
stringKK) /
emailKK0 5
)KK5 6
{LL 	
varMM 
listaUsuariosMM 
=MM 
_repositoryMM  +
.MM+ ,
GetAllMM, 2
(MM2 3
)MM3 4
.MM4 5
WhereMM5 :
(MM: ;
uMM; <
=>MM= ?
uMM@ A
.MMA B
EmailMMB G
==MMH J
emailMMK P
)MMP Q
.MMQ R
ToListMMR X
(MMX Y
)MMY Z
;MMZ [
returnOO 
listaUsuariosOO  
.OO  !
CountOO! &
>OO' (
$numOO) *
?OO+ ,
listaUsuariosOO- :
.OO: ;
FirstOO; @
(OO@ A
)OOA B
:OOC D
nullOOE I
;OOI J
}PP 	
publicRR 
UsuarioRR %
GetUsuarioByEmailAndSenhaRR 0
(RR0 1
stringRR1 7
emailRR8 =
,RR= >
stringRR? E
senhaRRF K
)RRK L
{SS 	
varTT 
listaUsuariosTT 
=TT 
_repositoryTT  +
.TT+ ,
GetAllTT, 2
(TT2 3
)TT3 4
.TT4 5
WhereTT5 :
(TT: ;
uTT; <
=>TT= ?
uTT@ A
.TTA B
EmailTTB G
==TTH J
emailTTK P
&&TTQ S
uTTT U
.TTU V
SenhaTTV [
==TT\ ^
senhaTT_ d
)TTd e
.TTe f
ToListTTf l
(TTl m
)TTm n
;TTn o
returnVV 
listaUsuariosVV  
.VV  !
CountVV! &
>VV' (
$numVV) *
?VV+ ,
listaUsuariosVV- :
.VV: ;
FirstVV; @
(VV@ A
)VVA B
:VVC D
nullVVE I
;VVI J
}WW 	
publicYY 
voidYY 
UpdateYY 
(YY 
UsuarioYY "
usuarioYY# *
)YY* +
{ZZ 	
_repository[[ 
.[[ 
Update[[ 
([[ 
usuario[[ &
)[[& '
;[[' (
}\\ 	
}]] 
}^^ 