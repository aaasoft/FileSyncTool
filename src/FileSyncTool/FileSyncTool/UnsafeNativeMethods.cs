using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security;

namespace FileSyncTool
{
	[SuppressUnmanagedCodeSecurity]
	public static class UnsafeNativeMethods
	{
		public struct POINTSTRUCT
		{
			public int x;

			public int y;

			public POINTSTRUCT(int x, int y)
			{
				this.x = x;
				this.y = y;
			}
		}

		public struct LPTRACKMOUSEEVENT
		{
			public uint cbSize;

			public uint dwFlags;

			public IntPtr hwndTrack;

			public uint dwHoverTime;
		}

		public enum MouseEventFlags
		{
			LeftDown = 2,
			LeftUp = 4,
			Click = 6,
			MiddleDown = 32,
			MiddleUp = 64,
			Move = 1,
			Absolute = 32768,
			RightDown = 8,
			RightUp = 16
		}

		public static class NativeMethods
		{
			public const int ACM_OPENA = 1124;

			public const int ACM_OPENW = 1127;

			public const int ADVF_NODATA = 1;

			public const int ADVF_ONLYONCE = 4;

			public const int ADVF_PRIMEFIRST = 2;

			public const int ALTERNATE = 1;

			public const int ANSI_CHARSET = 0;

			public const int ARW_BOTTOMLEFT = 0;

			public const int ARW_BOTTOMRIGHT = 1;

			public const int ARW_DOWN = 4;

			public const int ARW_HIDE = 8;

			public const int ARW_LEFT = 0;

			public const int ARW_RIGHT = 0;

			public const int ARW_TOPLEFT = 2;

			public const int ARW_TOPRIGHT = 3;

			public const int ARW_UP = 4;

			public const int ATTR_CONVERTED = 2;

			public const int ATTR_FIXEDCONVERTED = 5;

			public const int ATTR_INPUT = 0;

			public const int ATTR_INPUT_ERROR = 4;

			public const int ATTR_TARGET_CONVERTED = 1;

			public const int ATTR_TARGET_NOTCONVERTED = 3;

			public const int AUTOAPPEND = 1073741824;

			public const int AUTOAPPEND_OFF = int.MinValue;

			public const int AUTOSUGGEST = 268435456;

			public const int AUTOSUGGEST_OFF = 536870912;

			public const int BCM_GETIDEALSIZE = 5633;

			public const int BDR_RAISED = 5;

			public const int BDR_RAISEDINNER = 4;

			public const int BDR_RAISEDOUTER = 1;

			public const int BDR_SUNKEN = 10;

			public const int BDR_SUNKENINNER = 8;

			public const int BDR_SUNKENOUTER = 2;

			public const int BF_ADJUST = 8192;

			public const int BF_BOTTOM = 8;

			public const int BF_FLAT = 16384;

			public const int BF_LEFT = 1;

			public const int BF_MIDDLE = 2048;

			public const int BF_RIGHT = 4;

			public const int BF_TOP = 2;

			public const int BFFM_ENABLEOK = 1125;

			public const int BFFM_INITIALIZED = 1;

			public const int BFFM_SELCHANGED = 2;

			public const int BFFM_SETSELECTIONA = 1126;

			public const int BFFM_SETSELECTIONW = 1127;

			public const int BI_BITFIELDS = 3;

			public const int BI_RGB = 0;

			public const int BITMAPINFO_MAX_COLORSIZE = 256;

			public const int BITSPIXEL = 12;

			public const int BM_CLICK = 245;

			public const int BM_SETCHECK = 241;

			public const int BM_SETSTATE = 243;

			public const int BN_CLICKED = 0;

			public const int BS_3STATE = 5;

			public const int BS_BOTTOM = 2048;

			public const int BS_CENTER = 768;

			public const int BS_DEFPUSHBUTTON = 1;

			public const int BS_GROUPBOX = 7;

			public const int BS_LEFT = 256;

			public const int BS_MULTILINE = 8192;

			public const int BS_OWNERDRAW = 11;

			public const int BS_PATTERN = 3;

			public const int BS_PUSHBUTTON = 0;

			public const int BS_PUSHLIKE = 4096;

			public const int BS_RADIOBUTTON = 4;

			public const int BS_RIGHT = 512;

			public const int BS_RIGHTBUTTON = 32;

			public const int BS_SOLID = 0;

			public const int BS_TOP = 1024;

			public const int BS_VCENTER = 3072;

			public const int CB_ADDSTRING = 323;

			public const int CB_DELETESTRING = 324;

			public const int CB_ERR = -1;

			public const int CB_FINDSTRING = 332;

			public const int CB_FINDSTRINGEXACT = 344;

			public const int CB_GETCURSEL = 327;

			public const int CB_GETDROPPEDSTATE = 343;

			public const int CB_GETDROPPEDWIDTH = 351;

			public const int CB_GETEDITSEL = 320;

			public const int CB_GETITEMDATA = 336;

			public const int CB_GETITEMHEIGHT = 340;

			public const int CB_GETLBTEXT = 328;

			public const int CB_GETLBTEXTLEN = 329;

			public const int CB_INSERTSTRING = 330;

			public const int CB_LIMITTEXT = 321;

			public const int CB_RESETCONTENT = 331;

			public const int CB_SETCURSEL = 334;

			public const int CB_SETDROPPEDWIDTH = 352;

			public const int CB_SETEDITSEL = 322;

			public const int CB_SETITEMHEIGHT = 339;

			public const int CB_SHOWDROPDOWN = 335;

			public const int CBEM_GETITEMA = 1028;

			public const int CBEM_GETITEMW = 1037;

			public const int CBEM_INSERTITEMA = 1025;

			public const int CBEM_INSERTITEMW = 1035;

			public const int CBEM_SETITEMA = 1029;

			public const int CBEM_SETITEMW = 1036;

			public const int CBEN_ENDEDITA = -805;

			public const int CBEN_ENDEDITW = -806;

			public const int CBN_CLOSEUP = 8;

			public const int CBN_DBLCLK = 2;

			public const int CBN_DROPDOWN = 7;

			public const int CBN_EDITCHANGE = 5;

			public const int CBN_EDITUPDATE = 6;

			public const int CBN_SELCHANGE = 1;

			public const int CBN_SELENDOK = 9;

			public const int CBS_AUTOHSCROLL = 64;

			public const int CBS_DROPDOWN = 2;

			public const int CBS_DROPDOWNLIST = 3;

			public const int CBS_HASSTRINGS = 512;

			public const int CBS_NOINTEGRALHEIGHT = 1024;

			public const int CBS_OWNERDRAWFIXED = 16;

			public const int CBS_OWNERDRAWVARIABLE = 32;

			public const int CBS_SIMPLE = 1;

			public const int CC_ANYCOLOR = 256;

			public const int CC_ENABLEHOOK = 16;

			public const int CC_FULLOPEN = 2;

			public const int CC_PREVENTFULLOPEN = 4;

			public const int CC_RGBINIT = 1;

			public const int CC_SHOWHELP = 8;

			public const int CC_SOLIDCOLOR = 128;

			public const int CCM_GETVERSION = 8200;

			public const int CCM_SETVERSION = 8199;

			public const int CCS_NODIVIDER = 64;

			public const int CCS_NOPARENTALIGN = 8;

			public const int CCS_NORESIZE = 4;

			public const int CDDS_ITEM = 65536;

			public const int CDDS_ITEMPOSTPAINT = 65538;

			public const int CDDS_ITEMPREPAINT = 65537;

			public const int CDDS_POSTPAINT = 2;

			public const int CDDS_PREPAINT = 1;

			public const int CDDS_SUBITEM = 131072;

			public const int CDERR_DIALOGFAILURE = 65535;

			public const int CDERR_FINDRESFAILURE = 6;

			public const int CDERR_INITIALIZATION = 2;

			public const int CDERR_LOADRESFAILURE = 7;

			public const int CDERR_LOADSTRFAILURE = 5;

			public const int CDERR_LOCKRESFAILURE = 8;

			public const int CDERR_MEMALLOCFAILURE = 9;

			public const int CDERR_MEMLOCKFAILURE = 10;

			public const int CDERR_NOHINSTANCE = 4;

			public const int CDERR_NOHOOK = 11;

			public const int CDERR_NOTEMPLATE = 3;

			public const int CDERR_REGISTERMSGFAIL = 12;

			public const int CDERR_STRUCTSIZE = 1;

			public const int CDIS_CHECKED = 8;

			public const int CDIS_DEFAULT = 32;

			public const int CDIS_DISABLED = 4;

			public const int CDIS_FOCUS = 16;

			public const int CDIS_GRAYED = 2;

			public const int CDIS_HOT = 64;

			public const int CDIS_INDETERMINATE = 256;

			public const int CDIS_MARKED = 128;

			public const int CDIS_SELECTED = 1;

			public const int CDIS_SHOWKEYBOARDCUES = 512;

			public const int CDRF_DODEFAULT = 0;

			public const int CDRF_NEWFONT = 2;

			public const int CDRF_NOTIFYITEMDRAW = 32;

			public const int CDRF_NOTIFYPOSTPAINT = 16;

			public const int CDRF_NOTIFYSUBITEMDRAW = 32;

			public const int CDRF_SKIPDEFAULT = 4;

			public const int CF_APPLY = 512;

			public const int CF_BITMAP = 2;

			public const int CF_DIB = 8;

			public const int CF_DIF = 5;

			public const int CF_EFFECTS = 256;

			public const int CF_ENABLEHOOK = 8;

			public const int CF_ENHMETAFILE = 14;

			public const int CF_FIXEDPITCHONLY = 16384;

			public const int CF_FORCEFONTEXIST = 65536;

			public const int CF_HDROP = 15;

			public const int CF_INITTOLOGFONTSTRUCT = 64;

			public const int CF_LIMITSIZE = 8192;

			public const int CF_LOCALE = 16;

			public const int CF_METAFILEPICT = 3;

			public const int CF_NOSIMULATIONS = 4096;

			public const int CF_NOVECTORFONTS = 2048;

			public const int CF_NOVERTFONTS = 16777216;

			public const int CF_OEMTEXT = 7;

			public const int CF_PALETTE = 9;

			public const int CF_PENDATA = 10;

			public const int CF_RIFF = 11;

			public const int CF_SCREENFONTS = 1;

			public const int CF_SCRIPTSONLY = 1024;

			public const int CF_SELECTSCRIPT = 4194304;

			public const int CF_SHOWHELP = 4;

			public const int CF_SYLK = 4;

			public const int CF_TEXT = 1;

			public const int CF_TIFF = 6;

			public const int CF_TTONLY = 262144;

			public const int CF_UNICODETEXT = 13;

			public const int CF_WAVE = 12;

			public const int CFERR_MAXLESSTHANMIN = 8194;

			public const int CFERR_NOFONTS = 8193;

			public const int CHILDID_SELF = 0;

			public const int CLR_DEFAULT = -16777216;

			public const int CLR_NONE = -1;

			public const int CLSCTX_INPROC_SERVER = 1;

			public const int CLSCTX_LOCAL_SERVER = 4;

			public const int cmb4 = 1139;

			public const int COLOR_WINDOW = 5;

			public const int CONNECT_E_CANNOTCONNECT = -2147220990;

			public const int CONNECT_E_NOCONNECTION = -2147220992;

			public const int CP_WINANSI = 1004;

			public const int CPS_CANCEL = 4;

			public const int CPS_COMPLETE = 1;

			public const int CS_DBLCLKS = 8;

			public const int CS_DROPSHADOW = 131072;

			public const int CS_SAVEBITS = 2048;

			public const int CSC_NAVIGATEBACK = 2;

			public const int CSC_NAVIGATEFORWARD = 1;

			public const int CSIDL_APPDATA = 26;

			public const int CSIDL_COMMON_APPDATA = 35;

			public const int CSIDL_COOKIES = 33;

			public const int CSIDL_DESKTOP = 0;

			public const int CSIDL_DESKTOPDIRECTORY = 16;

			public const int CSIDL_FAVORITES = 6;

			public const int CSIDL_HISTORY = 34;

			public const int CSIDL_INTERNET = 1;

			public const int CSIDL_INTERNET_CACHE = 32;

			public const int CSIDL_LOCAL_APPDATA = 28;

			public const int CSIDL_PERSONAL = 5;

			public const int CSIDL_PROGRAM_FILES = 38;

			public const int CSIDL_PROGRAM_FILES_COMMON = 43;

			public const int CSIDL_PROGRAMS = 2;

			public const int CSIDL_RECENT = 8;

			public const int CSIDL_SENDTO = 9;

			public const int CSIDL_STARTMENU = 11;

			public const int CSIDL_STARTUP = 7;

			public const int CSIDL_SYSTEM = 37;

			public const int CSIDL_TEMPLATES = 21;

			public const int CTRLINFO_EATS_ESCAPE = 2;

			public const int CTRLINFO_EATS_RETURN = 1;

			public const int CW_USEDEFAULT = int.MinValue;

			public const int CWP_SKIPINVISIBLE = 1;

			public const int DCX_CACHE = 2;

			public const int DCX_INTERSECTRGN = 128;

			public const int DCX_LOCKWINDOWUPDATE = 1024;

			public const int DCX_WINDOW = 1;

			public const int DEFAULT_CHARSET = 1;

			public const int DEFAULT_GUI_FONT = 17;

			public const int DFC_BUTTON = 4;

			public const int DFC_CAPTION = 1;

			public const int DFC_MENU = 2;

			public const int DFC_SCROLL = 3;

			public const int DFCS_BUTTON3STATE = 8;

			public const int DFCS_BUTTONCHECK = 0;

			public const int DFCS_BUTTONPUSH = 16;

			public const int DFCS_BUTTONRADIO = 4;

			public const int DFCS_CAPTIONCLOSE = 0;

			public const int DFCS_CAPTIONHELP = 4;

			public const int DFCS_CAPTIONMAX = 2;

			public const int DFCS_CAPTIONMIN = 1;

			public const int DFCS_CAPTIONRESTORE = 3;

			public const int DFCS_CHECKED = 1024;

			public const int DFCS_FLAT = 16384;

			public const int DFCS_INACTIVE = 256;

			public const int DFCS_MENUARROW = 0;

			public const int DFCS_MENUBULLET = 2;

			public const int DFCS_MENUCHECK = 1;

			public const int DFCS_PUSHED = 512;

			public const int DFCS_SCROLLCOMBOBOX = 5;

			public const int DFCS_SCROLLDOWN = 1;

			public const int DFCS_SCROLLLEFT = 2;

			public const int DFCS_SCROLLRIGHT = 3;

			public const int DFCS_SCROLLUP = 0;

			public const int DI_NORMAL = 3;

			public const int DIB_RGB_COLORS = 0;

			public const int DISP_E_EXCEPTION = -2147352567;

			public const int DISP_E_MEMBERNOTFOUND = -2147352573;

			public const int DISP_E_PARAMNOTFOUND = -2147352572;

			public const int DISPATCH_METHOD = 1;

			public const int DISPATCH_PROPERTYGET = 2;

			public const int DISPATCH_PROPERTYPUT = 4;

			public const int DISPID_PROPERTYPUT = -3;

			public const int DISPID_UNKNOWN = -1;

			public const int DLGC_HASSETSEL = 8;

			public const int DLGC_WANTALLKEYS = 4;

			public const int DLGC_WANTARROWS = 1;

			public const int DLGC_WANTCHARS = 128;

			public const int DLGC_WANTMESSAGE = 4;

			public const int DLGC_WANTTAB = 2;

			public const int DM_DISPLAYORIENTATION = 128;

			public const int DRAGDROP_E_ALREADYREGISTERED = -2147221247;

			public const int DRAGDROP_E_NOTREGISTERED = -2147221248;

			public const int DTM_GETMONTHCAL = 4104;

			public const int DTM_GETSYSTEMTIME = 4097;

			public const int DTM_SETFORMATA = 4101;

			public const int DTM_SETFORMATW = 4146;

			public const int DTM_SETMCCOLOR = 4102;

			public const int DTM_SETMCFONT = 4105;

			public const int DTM_SETRANGE = 4100;

			public const int DTM_SETSYSTEMTIME = 4098;

			public const int DTN_CLOSEUP = -753;

			public const int DTN_DATETIMECHANGE = -759;

			public const int DTN_DROPDOWN = -754;

			public const int DTN_FORMATA = -756;

			public const int DTN_FORMATQUERYA = -755;

			public const int DTN_FORMATQUERYW = -742;

			public const int DTN_FORMATW = -743;

			public const int DTN_USERSTRINGA = -758;

			public const int DTN_USERSTRINGW = -745;

			public const int DTN_WMKEYDOWNA = -757;

			public const int DTN_WMKEYDOWNW = -744;

			public const int DTS_LONGDATEFORMAT = 4;

			public const int DTS_RIGHTALIGN = 32;

			public const int DTS_SHOWNONE = 2;

			public const int DTS_TIMEFORMAT = 9;

			public const int DTS_UPDOWN = 1;

			public const int DUPLICATE = 6;

			public const int DUPLICATE_SAME_ACCESS = 2;

			public const int DV_E_DVASPECT = -2147221397;

			public const int DVASPECT_CONTENT = 1;

			public const int DVASPECT_OPAQUE = 16;

			public const int DVASPECT_TRANSPARENT = 32;

			public const int E_ABORT = -2147467260;

			public const int E_FAIL = -2147467259;

			public const int E_INVALIDARG = -2147024809;

			public const int E_NOINTERFACE = -2147467262;

			public const int E_NOTIMPL = -2147467263;

			public const int E_OUTOFMEMORY = -2147024882;

			public const int E_UNEXPECTED = -2147418113;

			public const int EC_LEFTMARGIN = 1;

			public const int EC_RIGHTMARGIN = 2;

			public const int EDGE_BUMP = 9;

			public const int EDGE_ETCHED = 6;

			public const int EDGE_RAISED = 5;

			public const int EDGE_SUNKEN = 10;

			public const int EM_CANUNDO = 198;

			public const int EM_CHARFROMPOS = 215;

			public const int EM_EMPTYUNDOBUFFER = 205;

			public const int EM_GETFIRSTVISIBLELINE = 206;

			public const int EM_GETLINE = 196;

			public const int EM_GETLINECOUNT = 186;

			public const int EM_GETMODIFY = 184;

			public const int EM_GETPASSWORDCHAR = 210;

			public const int EM_GETSEL = 176;

			public const int EM_LIMITTEXT = 197;

			public const int EM_LINEFROMCHAR = 201;

			public const int EM_LINEINDEX = 187;

			public const int EM_POSFROMCHAR = 214;

			public const int EM_REPLACESEL = 194;

			public const int EM_SCROLL = 181;

			public const int EM_SCROLLCARET = 183;

			public const int EM_SETMARGINS = 211;

			public const int EM_SETMODIFY = 185;

			public const int EM_SETPASSWORDCHAR = 204;

			public const int EM_SETREADONLY = 207;

			public const int EM_SETSEL = 177;

			public const int EM_UNDO = 199;

			public const int EMR_POLYTEXTOUTA = 96;

			public const int EMR_POLYTEXTOUTW = 97;

			public const int EN_ALIGN_LTR_EC = 1792;

			public const int EN_ALIGN_RTL_EC = 1793;

			public const int EN_CHANGE = 768;

			public const int EN_HSCROLL = 1537;

			public const int EN_UPDATE = 1024;

			public const int EN_VSCROLL = 1538;

			public const int ERROR_CLASS_ALREADY_EXISTS = 1410;

			public const int ERROR_INVALID_HANDLE = 6;

			public const int ES_AUTOHSCROLL = 128;

			public const int ES_AUTOVSCROLL = 64;

			public const int ES_CENTER = 1;

			public const int ES_LEFT = 0;

			public const int ES_LOWERCASE = 16;

			public const int ES_MULTILINE = 4;

			public const int ES_NOHIDESEL = 256;

			public const int ES_PASSWORD = 32;

			public const int ES_READONLY = 2048;

			public const int ES_RIGHT = 2;

			public const int ES_UPPERCASE = 8;

			public const int ESB_DISABLE_BOTH = 3;

			public const int ESB_ENABLE_BOTH = 0;

			public const int ETO_CLIPPED = 4;

			public const int ETO_OPAQUE = 2;

			public const int FADF_BSTR = 256;

			public const int FADF_DISPATCH = 1024;

			public const int FADF_UNKNOWN = 512;

			public const int FADF_VARIANT = 2048;

			public const int FALT = 16;

			public const int FILE_MAP_COPY = 1;

			public const int FILE_MAP_READ = 4;

			public const int FILE_MAP_WRITE = 2;

			public const int FNERR_BUFFERTOOSMALL = 12291;

			public const int FNERR_INVALIDFILENAME = 12290;

			public const int FNERR_SUBCLASSFAILURE = 12289;

			public const int FORMAT_MESSAGE_FROM_SYSTEM = 4096;

			public const int FORMAT_MESSAGE_IGNORE_INSERTS = 512;

			public const int FRERR_BUFFERLENGTHZERO = 16385;

			public const int FSHIFT = 4;

			public const int FVIRTKEY = 1;

			public const int FW_BOLD = 700;

			public const int FW_DONTCARE = 0;

			public const int FW_NORMAL = 400;

			public const int GA_PARENT = 1;

			public const int GA_ROOT = 2;

			public const int GCL_WNDPROC = -24;

			public const int GCS_COMPATTR = 16;

			public const int GCS_COMPSTR = 8;

			public const int GCS_RESULTSTR = 2048;

			public const int GDI_ERROR = -1;

			public const int GDT_NONE = 1;

			public const int GDT_VALID = 0;

			public const int GDTR_MAX = 2;

			public const int GDTR_MIN = 1;

			public const int GHND = 66;

			public const int GM_ADVANCED = 2;

			public const int GM_COMPATIBLE = 1;

			public const int GMEM_DDESHARE = 8192;

			public const int GMEM_DISCARDABLE = 256;

			public const int GMEM_FIXED = 0;

			public const int GMEM_INVALID_HANDLE = 32768;

			public const int GMEM_LOWER = 4096;

			public const int GMEM_MODIFY = 128;

			public const int GMEM_MOVEABLE = 2;

			public const int GMEM_NOCOMPACT = 16;

			public const int GMEM_NODISCARD = 32;

			public const int GMEM_NOT_BANKED = 4096;

			public const int GMEM_NOTIFY = 16384;

			public const int GMEM_SHARE = 8192;

			public const int GMEM_VALID_FLAGS = 32626;

			public const int GMEM_ZEROINIT = 64;

			public const int GMR_DAYSTATE = 1;

			public const int GMR_VISIBLE = 0;

			public const int GPTR = 64;

			public const int GW_CHILD = 5;

			public const int GW_HWNDFIRST = 0;

			public const int GW_HWNDLAST = 1;

			public const int GW_HWNDNEXT = 2;

			public const int GW_HWNDPREV = 3;

			public const int GWL_EXSTYLE = -20;

			public const int GWL_HWNDPARENT = -8;

			public const int GWL_ID = -12;

			public const int GWL_STYLE = -16;

			public const int GWL_WNDPROC = -4;

			public const int HBMMENU_CALLBACK = -1;

			public const int HBMMENU_MBAR_CLOSE = 5;

			public const int HBMMENU_MBAR_CLOSE_D = 6;

			public const int HBMMENU_MBAR_MINIMIZE = 3;

			public const int HBMMENU_MBAR_MINIMIZE_D = 7;

			public const int HBMMENU_MBAR_RESTORE = 2;

			public const int HBMMENU_POPUP_CLOSE = 8;

			public const int HBMMENU_POPUP_MAXIMIZE = 10;

			public const int HBMMENU_POPUP_MINIMIZE = 11;

			public const int HBMMENU_POPUP_RESTORE = 9;

			public const int HBMMENU_SYSTEM = 1;

			public const int HC_ACTION = 0;

			public const int HC_GETNEXT = 1;

			public const int HC_SKIP = 2;

			public const int HCF_HIGHCONTRASTON = 1;

			public const int HDI_ORDER = 128;

			public const int HDI_WIDTH = 1;

			public const int HDM_GETITEMA = 4611;

			public const int HDM_GETITEMCOUNT = 4608;

			public const int HDM_GETITEMW = 4619;

			public const int HDM_INSERTITEMA = 4609;

			public const int HDM_INSERTITEMW = 4618;

			public const int HDM_LAYOUT = 4613;

			public const int HDM_SETITEMA = 4612;

			public const int HDM_SETITEMW = 4620;

			public const int HDN_BEGINTDRAG = -310;

			public const int HDN_BEGINTRACKA = -306;

			public const int HDN_BEGINTRACKW = -326;

			public const int HDN_DIVIDERDBLCLICKA = -305;

			public const int HDN_DIVIDERDBLCLICKW = -325;

			public const int HDN_ENDDRAG = -311;

			public const int HDN_ENDTRACKA = -307;

			public const int HDN_ENDTRACKW = -327;

			public const int HDN_GETDISPINFOA = -309;

			public const int HDN_GETDISPINFOW = -329;

			public const int HDN_ITEMCHANGEDA = -301;

			public const int HDN_ITEMCHANGEDW = -321;

			public const int HDN_ITEMCHANGINGA = -300;

			public const int HDN_ITEMCHANGINGW = -320;

			public const int HDN_ITEMCLICKA = -302;

			public const int HDN_ITEMCLICKW = -322;

			public const int HDN_ITEMDBLCLICKA = -303;

			public const int HDN_ITEMDBLCLICKW = -323;

			public const int HDN_TRACKA = -308;

			public const int HDN_TRACKW = -328;

			public const int HDS_FULLDRAG = 128;

			public const int HELPINFO_WINDOW = 1;

			public const int HH_FTS_DEFAULT_PROXIMITY = -1;

			public const int HICF_ACCELERATOR = 4;

			public const int HICF_ARROWKEYS = 2;

			public const int HICF_DUPACCEL = 8;

			public const int HICF_ENTERING = 16;

			public const int HICF_LEAVING = 32;

			public const int HICF_LMOUSE = 128;

			public const int HICF_MOUSE = 1;

			public const int HICF_OTHER = 0;

			public const int HICF_RESELECT = 64;

			public const int HICF_TOGGLEDROPDOWN = 256;

			public const int HLP_FILE = 1;

			public const int HLP_KEYWORD = 2;

			public const int HLP_NAVIGATOR = 3;

			public const int HLP_OBJECT = 4;

			public const int HOLLOW_BRUSH = 5;

			public const int HTBORDER = 18;

			public const int HTBOTTOM = 15;

			public const int HTBOTTOMLEFT = 16;

			public const int HTBOTTOMRIGHT = 17;

			public const int HTCLIENT = 1;

			public const int HTLEFT = 10;

			public const int HTNOWHERE = 0;

			public const int HTTRANSPARENT = -1;

			public const int ICC_BAR_CLASSES = 4;

			public const int ICC_DATE_CLASSES = 256;

			public const int ICC_LISTVIEW_CLASSES = 1;

			public const int ICC_PROGRESS_CLASS = 32;

			public const int ICC_TAB_CLASSES = 8;

			public const int ICC_TREEVIEW_CLASSES = 2;

			public const int ICON_BIG = 1;

			public const int ICON_SMALL = 0;

			public const int IDC_APPSTARTING = 32650;

			public const int IDC_ARROW = 32512;

			public const int IDC_CROSS = 32515;

			public const int IDC_HELP = 32651;

			public const int IDC_IBEAM = 32513;

			public const int IDC_NO = 32648;

			public const int IDC_SIZEALL = 32646;

			public const int IDC_SIZENESW = 32643;

			public const int IDC_SIZENS = 32645;

			public const int IDC_SIZENWSE = 32642;

			public const int IDC_SIZEWE = 32644;

			public const int IDC_UPARROW = 32516;

			public const int IDC_WAIT = 32514;

			public const int IDM_PAGESETUP = 2004;

			public const int IDM_PRINT = 27;

			public const int IDM_PRINTPREVIEW = 2003;

			public const int IDM_PROPERTIES = 28;

			public const int IDM_SAVEAS = 71;

			public const int ILC_COLOR = 0;

			public const int ILC_COLOR16 = 16;

			public const int ILC_COLOR24 = 24;

			public const int ILC_COLOR32 = 32;

			public const int ILC_COLOR4 = 4;

			public const int ILC_COLOR8 = 8;

			public const int ILC_MASK = 1;

			public const int ILC_MIRROR = 8192;

			public const int ILD_MASK = 16;

			public const int ILD_NORMAL = 0;

			public const int ILD_ROP = 64;

			public const int ILD_TRANSPARENT = 1;

			public const int ILP_DOWNLEVEL = 1;

			public const int ILP_NORMAL = 0;

			public const int ILS_ALPHA = 8;

			public const int ILS_GLOW = 1;

			public const int ILS_NORMAL = 0;

			public const int ILS_SATURATE = 4;

			public const int ILS_SHADOW = 2;

			public const int IMAGE_CURSOR = 2;

			public const int IMAGE_ICON = 1;

			public const int IME_CMODE_FULLSHAPE = 8;

			public const int IME_CMODE_KATAKANA = 2;

			public const int IME_CMODE_NATIVE = 1;

			public const int IMN_OPENSTATUSWINDOW = 2;

			public const int IMN_SETCONVERSIONMODE = 6;

			public const int IMN_SETOPENSTATUS = 8;

			public const int INET_E_DEFAULT_ACTION = -2146697199;

			public const int INPLACE_E_NOTOOLSPACE = -2147221087;

			public const int INPUT_KEYBOARD = 1;

			public const int KEYEVENTF_EXTENDEDKEY = 1;

			public const int KEYEVENTF_KEYUP = 2;

			public const int KEYEVENTF_UNICODE = 4;

			public const int LANG_NEUTRAL = 0;

			public const int LB_ADDSTRING = 384;

			public const int LB_DELETESTRING = 386;

			public const int LB_ERR = -1;

			public const int LB_ERRSPACE = -2;

			public const int LB_FINDSTRING = 399;

			public const int LB_FINDSTRINGEXACT = 418;

			public const int LB_GETCARETINDEX = 415;

			public const int LB_GETCURSEL = 392;

			public const int LB_GETITEMHEIGHT = 417;

			public const int LB_GETITEMRECT = 408;

			public const int LB_GETSEL = 391;

			public const int LB_GETSELCOUNT = 400;

			public const int LB_GETSELITEMS = 401;

			public const int LB_GETTEXT = 393;

			public const int LB_GETTEXTLEN = 394;

			public const int LB_GETTOPINDEX = 398;

			public const int LB_INSERTSTRING = 385;

			public const int LB_ITEMFROMPOINT = 425;

			public const int LB_RESETCONTENT = 388;

			public const int LB_SETCOLUMNWIDTH = 405;

			public const int LB_SETCURSEL = 390;

			public const int LB_SETHORIZONTALEXTENT = 404;

			public const int LB_SETITEMHEIGHT = 416;

			public const int LB_SETLOCALE = 421;

			public const int LB_SETSEL = 389;

			public const int LB_SETTABSTOPS = 402;

			public const int LB_SETTOPINDEX = 407;

			public const int LBN_DBLCLK = 2;

			public const int LBN_SELCHANGE = 1;

			public const int LBS_DISABLENOSCROLL = 4096;

			public const int LBS_EXTENDEDSEL = 2048;

			public const int LBS_HASSTRINGS = 64;

			public const int LBS_MULTICOLUMN = 512;

			public const int LBS_MULTIPLESEL = 8;

			public const int LBS_NOINTEGRALHEIGHT = 256;

			public const int LBS_NOSEL = 16384;

			public const int LBS_NOTIFY = 1;

			public const int LBS_OWNERDRAWFIXED = 16;

			public const int LBS_OWNERDRAWVARIABLE = 32;

			public const int LBS_USETABSTOPS = 128;

			public const int LBS_WANTKEYBOARDINPUT = 1024;

			public const int LOCALE_IFIRSTDAYOFWEEK = 4108;

			public const int LOCALE_IMEASURE = 13;

			public const int LOCK_EXCLUSIVE = 2;

			public const int LOCK_ONLYONCE = 4;

			public const int LOCK_WRITE = 1;

			public const int LOGPIXELSX = 88;

			public const int LOGPIXELSY = 90;

			public const int LV_VIEW_TILE = 4;

			public const int LVA_ALIGNLEFT = 1;

			public const int LVA_ALIGNTOP = 2;

			public const int LVA_DEFAULT = 0;

			public const int LVA_SNAPTOGRID = 5;

			public const int LVBKIF_SOURCE_NONE = 0;

			public const int LVBKIF_SOURCE_URL = 2;

			public const int LVBKIF_STYLE_NORMAL = 0;

			public const int LVBKIF_STYLE_TILE = 16;

			public const int LVCDI_GROUP = 1;

			public const int LVCDI_ITEM = 0;

			public const int LVCF_FMT = 1;

			public const int LVCF_IMAGE = 16;

			public const int LVCF_ORDER = 32;

			public const int LVCF_SUBITEM = 8;

			public const int LVCF_TEXT = 4;

			public const int LVCF_WIDTH = 2;

			public const int LVCFMT_IMAGE = 2048;

			public const int LVFI_NEARESTXY = 64;

			public const int LVFI_PARAM = 1;

			public const int LVFI_PARTIAL = 8;

			public const int LVFI_STRING = 2;

			public const int LVGA_FOOTER_CENTER = 16;

			public const int LVGA_FOOTER_LEFT = 8;

			public const int LVGA_FOOTER_RIGHT = 32;

			public const int LVGA_HEADER_CENTER = 2;

			public const int LVGA_HEADER_LEFT = 1;

			public const int LVGA_HEADER_RIGHT = 4;

			public const int LVGF_ALIGN = 8;

			public const int LVGF_FOOTER = 2;

			public const int LVGF_GROUPID = 16;

			public const int LVGF_HEADER = 1;

			public const int LVGF_NONE = 0;

			public const int LVGF_STATE = 4;

			public const int LVGS_COLLAPSED = 1;

			public const int LVGS_HIDDEN = 2;

			public const int LVGS_NORMAL = 0;

			public const int LVHT_ABOVE = 8;

			public const int LVHT_BELOW = 16;

			public const int LVHT_LEFT = 64;

			public const int LVHT_NOWHERE = 1;

			public const int LVHT_ONITEM = 14;

			public const int LVHT_ONITEMICON = 2;

			public const int LVHT_ONITEMLABEL = 4;

			public const int LVHT_ONITEMSTATEICON = 8;

			public const int LVHT_RIGHT = 32;

			public const int LVIF_COLUMNS = 512;

			public const int LVIF_GROUPID = 256;

			public const int LVIF_IMAGE = 2;

			public const int LVIF_INDENT = 16;

			public const int LVIF_PARAM = 4;

			public const int LVIF_STATE = 8;

			public const int LVIF_TEXT = 1;

			public const int LVIM_AFTER = 1;

			public const int LVIR_BOUNDS = 0;

			public const int LVIR_ICON = 1;

			public const int LVIR_LABEL = 2;

			public const int LVIR_SELECTBOUNDS = 3;

			public const int LVIS_CUT = 4;

			public const int LVIS_DROPHILITED = 8;

			public const int LVIS_FOCUSED = 1;

			public const int LVIS_OVERLAYMASK = 3840;

			public const int LVIS_SELECTED = 2;

			public const int LVIS_STATEIMAGEMASK = 61440;

			public const int LVM_ARRANGE = 4118;

			public const int LVM_DELETEALLITEMS = 4105;

			public const int LVM_DELETECOLUMN = 4124;

			public const int LVM_DELETEITEM = 4104;

			public const int LVM_EDITLABELA = 4119;

			public const int LVM_EDITLABELW = 4214;

			public const int LVM_ENABLEGROUPVIEW = 4253;

			public const int LVM_ENSUREVISIBLE = 4115;

			public const int LVM_FINDITEMA = 4109;

			public const int LVM_FINDITEMW = 4179;

			public const int LVM_GETCALLBACKMASK = 4106;

			public const int LVM_GETCOLUMNA = 4121;

			public const int LVM_GETCOLUMNORDERARRAY = 4155;

			public const int LVM_GETCOLUMNW = 4191;

			public const int LVM_GETCOLUMNWIDTH = 4125;

			public const int LVM_GETGROUPINFO = 4245;

			public const int LVM_GETHEADER = 4127;

			public const int LVM_GETHOTITEM = 4157;

			public const int LVM_GETINSERTMARK = 4263;

			public const int LVM_GETINSERTMARKCOLOR = 4267;

			public const int LVM_GETINSERTMARKRECT = 4265;

			public const int LVM_GETISEARCHSTRINGA = 4148;

			public const int LVM_GETISEARCHSTRINGW = 4213;

			public const int LVM_GETITEMA = 4101;

			public const int LVM_GETITEMCOUNT = 4100;

			public const int LVM_GETITEMPOSITION = 4112;

			public const int LVM_GETITEMRECT = 4110;

			public const int LVM_GETITEMSTATE = 4140;

			public const int LVM_GETITEMTEXTA = 4141;

			public const int LVM_GETITEMTEXTW = 4211;

			public const int LVM_GETITEMW = 4171;

			public const int LVM_GETNEXTITEM = 4108;

			public const int LVM_GETSELECTEDCOUNT = 4146;

			public const int LVM_GETSTRINGWIDTHA = 4113;

			public const int LVM_GETSTRINGWIDTHW = 4183;

			public const int LVM_GETSUBITEMRECT = 4152;

			public const int LVM_GETTILEVIEWINFO = 4259;

			public const int LVM_GETTOPINDEX = 4135;

			public const int LVM_HASGROUP = 4257;

			public const int LVM_HITTEST = 4114;

			public const int LVM_INSERTCOLUMNA = 4123;

			public const int LVM_INSERTCOLUMNW = 4193;

			public const int LVM_INSERTGROUP = 4241;

			public const int LVM_INSERTITEMA = 4103;

			public const int LVM_INSERTITEMW = 4173;

			public const int LVM_INSERTMARKHITTEST = 4264;

			public const int LVM_ISGROUPVIEWENABLED = 4271;

			public const int LVM_MOVEITEMTOGROUP = 4250;

			public const int LVM_REDRAWITEMS = 4117;

			public const int LVM_REMOVEALLGROUPS = 4256;

			public const int LVM_REMOVEGROUP = 4246;

			public const int LVM_SCROLL = 4116;

			public const int LVM_SETBKCOLOR = 4097;

			public const int LVM_SETBKIMAGEA = 4164;

			public const int LVM_SETBKIMAGEW = 4234;

			public const int LVM_SETCALLBACKMASK = 4107;

			public const int LVM_SETCOLUMNA = 4122;

			public const int LVM_SETCOLUMNORDERARRAY = 4154;

			public const int LVM_SETCOLUMNW = 4192;

			public const int LVM_SETCOLUMNWIDTH = 4126;

			public const int LVM_SETEXTENDEDLISTVIEWSTYLE = 4150;

			public const int LVM_SETGROUPINFO = 4243;

			public const int LVM_SETIMAGELIST = 4099;

			public const int LVM_SETINFOTIP = 4269;

			public const int LVM_SETINSERTMARK = 4262;

			public const int LVM_SETINSERTMARKCOLOR = 4266;

			public const int LVM_SETITEMA = 4102;

			public const int LVM_SETITEMCOUNT = 4143;

			public const int LVM_SETITEMPOSITION = 4111;

			public const int LVM_SETITEMPOSITION32 = 4145;

			public const int LVM_SETITEMSTATE = 4139;

			public const int LVM_SETITEMTEXTA = 4142;

			public const int LVM_SETITEMTEXTW = 4212;

			public const int LVM_SETITEMW = 4172;

			public const int LVM_SETSELECTIONMARK = 4163;

			public const int LVM_SETTEXTBKCOLOR = 4134;

			public const int LVM_SETTEXTCOLOR = 4132;

			public const int LVM_SETTILEVIEWINFO = 4258;

			public const int LVM_SETTOOLTIPS = 4170;

			public const int LVM_SETVIEW = 4238;

			public const int LVM_SORTITEMS = 4144;

			public const int LVM_SUBITEMHITTEST = 4153;

			public const int LVM_UPDATE = 4138;

			public const int LVN_BEGINDRAG = -109;

			public const int LVN_BEGINLABELEDITA = -105;

			public const int LVN_BEGINLABELEDITW = -175;

			public const int LVN_BEGINRDRAG = -111;

			public const int LVN_COLUMNCLICK = -108;

			public const int LVN_ENDLABELEDITA = -106;

			public const int LVN_ENDLABELEDITW = -176;

			public const int LVN_GETDISPINFOA = -150;

			public const int LVN_GETDISPINFOW = -177;

			public const int LVN_GETINFOTIPA = -157;

			public const int LVN_GETINFOTIPW = -158;

			public const int LVN_ITEMACTIVATE = -114;

			public const int LVN_ITEMCHANGED = -101;

			public const int LVN_ITEMCHANGING = -100;

			public const int LVN_KEYDOWN = -155;

			public const int LVN_ODCACHEHINT = -113;

			public const int LVN_ODFINDITEMA = -152;

			public const int LVN_ODFINDITEMW = -179;

			public const int LVN_ODSTATECHANGED = -115;

			public const int LVN_SETDISPINFOA = -151;

			public const int LVN_SETDISPINFOW = -178;

			public const int LVNI_FOCUSED = 1;

			public const int LVNI_SELECTED = 2;

			public const int LVS_ALIGNLEFT = 2048;

			public const int LVS_ALIGNTOP = 0;

			public const int LVS_AUTOARRANGE = 256;

			public const int LVS_EDITLABELS = 512;

			public const int LVS_EX_CHECKBOXES = 4;

			public const int LVS_EX_DOUBLEBUFFER = 65536;

			public const int LVS_EX_FULLROWSELECT = 32;

			public const int LVS_EX_GRIDLINES = 1;

			public const int LVS_EX_HEADERDRAGDROP = 16;

			public const int LVS_EX_INFOTIP = 1024;

			public const int LVS_EX_ONECLICKACTIVATE = 64;

			public const int LVS_EX_TRACKSELECT = 8;

			public const int LVS_EX_TWOCLICKACTIVATE = 128;

			public const int LVS_EX_UNDERLINEHOT = 2048;

			public const int LVS_ICON = 0;

			public const int LVS_LIST = 3;

			public const int LVS_NOCOLUMNHEADER = 16384;

			public const int LVS_NOLABELWRAP = 128;

			public const int LVS_NOSCROLL = 8192;

			public const int LVS_NOSORTHEADER = 32768;

			public const int LVS_OWNERDATA = 4096;

			public const int LVS_REPORT = 1;

			public const int LVS_SHAREIMAGELISTS = 64;

			public const int LVS_SHOWSELALWAYS = 8;

			public const int LVS_SINGLESEL = 4;

			public const int LVS_SMALLICON = 2;

			public const int LVS_SORTASCENDING = 16;

			public const int LVS_SORTDESCENDING = 32;

			public const int LVSCW_AUTOSIZE = -1;

			public const int LVSCW_AUTOSIZE_USEHEADER = -2;

			public const int LVSIL_NORMAL = 0;

			public const int LVSIL_SMALL = 1;

			public const int LVSIL_STATE = 2;

			public const int LVTVIF_FIXEDSIZE = 3;

			public const int LVTVIM_COLUMNS = 2;

			public const int LVTVIM_TILESIZE = 1;

			public const int LWA_ALPHA = 2;

			public const int LWA_COLORKEY = 1;

			public const int MA_ACTIVATE = 1;

			public const int MA_ACTIVATEANDEAT = 2;

			public const int MA_NOACTIVATE = 3;

			public const int MA_NOACTIVATEANDEAT = 4;

			public const int MAX_PATH = 260;

			public const int MB_OK = 0;

			public const int MCHT_CALENDAR = 131072;

			public const int MCHT_CALENDARBK = 131072;

			public const int MCHT_CALENDARDATE = 131073;

			public const int MCHT_CALENDARDATENEXT = 16908289;

			public const int MCHT_CALENDARDATEPREV = 33685505;

			public const int MCHT_CALENDARDAY = 131074;

			public const int MCHT_CALENDARWEEKNUM = 131075;

			public const int MCHT_TITLE = 65536;

			public const int MCHT_TITLEBK = 65536;

			public const int MCHT_TITLEBTNNEXT = 16842755;

			public const int MCHT_TITLEBTNPREV = 33619971;

			public const int MCHT_TITLEMONTH = 65537;

			public const int MCHT_TITLEYEAR = 65538;

			public const int MCHT_TODAYLINK = 196608;

			public const int MCM_GETMAXTODAYWIDTH = 4117;

			public const int MCM_GETMINREQRECT = 4105;

			public const int MCM_GETMONTHRANGE = 4103;

			public const int MCM_GETTODAY = 4109;

			public const int MCM_HITTEST = 4110;

			public const int MCM_SETCOLOR = 4106;

			public const int MCM_SETFIRSTDAYOFWEEK = 4111;

			public const int MCM_SETMAXSELCOUNT = 4100;

			public const int MCM_SETMONTHDELTA = 4116;

			public const int MCM_SETRANGE = 4114;

			public const int MCM_SETSELRANGE = 4102;

			public const int MCM_SETTODAY = 4108;

			public const int MCN_GETDAYSTATE = -747;

			public const int MCN_SELCHANGE = -749;

			public const int MCN_SELECT = -746;

			public const int MCS_DAYSTATE = 1;

			public const int MCS_MULTISELECT = 2;

			public const int MCS_NOTODAY = 16;

			public const int MCS_NOTODAYCIRCLE = 8;

			public const int MCS_WEEKNUMBERS = 4;

			public const int MCSC_MONTHBK = 4;

			public const int MCSC_TEXT = 1;

			public const int MCSC_TITLEBK = 2;

			public const int MCSC_TITLETEXT = 3;

			public const int MCSC_TRAILINGTEXT = 5;

			public const int MDIS_ALLCHILDSTYLES = 1;

			public const int MDITILE_HORIZONTAL = 1;

			public const int MDITILE_SKIPDISABLED = 2;

			public const int MDITILE_VERTICAL = 0;

			public const int MEMBERID_NIL = -1;

			public const int MF_BYCOMMAND = 0;

			public const int MF_BYPOSITION = 1024;

			public const int MF_ENABLED = 0;

			public const int MF_GRAYED = 1;

			public const int MF_POPUP = 16;

			public const int MF_SYSMENU = 8192;

			public const int MFS_DISABLED = 3;

			public const int MFT_MENUBREAK = 64;

			public const int MFT_RIGHTJUSTIFY = 16384;

			public const int MFT_RIGHTORDER = 8192;

			public const int MFT_SEPARATOR = 2048;

			public const int MIIM_BITMAP = 128;

			public const int MIIM_DATA = 32;

			public const int MIIM_FTYPE = 256;

			public const int MIIM_ID = 2;

			public const int MIIM_STATE = 1;

			public const int MIIM_STRING = 64;

			public const int MIIM_SUBMENU = 4;

			public const int MIIM_TYPE = 16;

			public const int MK_CONTROL = 8;

			public const int MK_LBUTTON = 1;

			public const int MK_MBUTTON = 16;

			public const int MK_RBUTTON = 2;

			public const int MK_SHIFT = 4;

			public const int MM_ANISOTROPIC = 8;

			public const int MM_HIMETRIC = 3;

			public const int MM_TEXT = 1;

			public const int MNC_EXECUTE = 2;

			public const int MNC_SELECT = 3;

			public const string MOUSEZ_CLASSNAME = "MouseZ";

			public const string MOUSEZ_TITLE = "Magellan MSWHEEL";

			public const int MSAA_MENU_SIG = -1441927155;

			public const string MSH_MOUSEWHEEL = "MSWHEEL_ROLLMSG";

			public const string MSH_SCROLL_LINES = "MSH_SCROLL_LINES_MSG";

			public const int MWT_IDENTITY = 1;

			public const int NFR_ANSI = 1;

			public const int NFR_UNICODE = 2;

			public const int NI_COMPOSITIONSTR = 21;

			public const int NIF_ICON = 2;

			public const int NIF_INFO = 16;

			public const int NIF_MESSAGE = 1;

			public const int NIF_TIP = 4;

			public const int NIIF_ERROR = 3;

			public const int NIIF_INFO = 1;

			public const int NIIF_NONE = 0;

			public const int NIIF_WARNING = 2;

			public const int NIM_ADD = 0;

			public const int NIM_DELETE = 2;

			public const int NIM_MODIFY = 1;

			public const int NIM_SETVERSION = 4;

			public const int NIN_BALLOONHIDE = 1027;

			public const int NIN_BALLOONSHOW = 1026;

			public const int NIN_BALLOONTIMEOUT = 1028;

			public const int NIN_BALLOONUSERCLICK = 1029;

			public const int NM_CLICK = -2;

			public const int NM_CUSTOMDRAW = -12;

			public const int NM_DBLCLK = -3;

			public const int NM_RCLICK = -5;

			public const int NM_RDBLCLK = -6;

			public const int NM_RELEASEDCAPTURE = -16;

			public const int NONANTIALIASED_QUALITY = 3;

			public const int NOTSRCCOPY = 3342344;

			public const int NULL_BRUSH = 5;

			public const int OBJ_BITMAP = 7;

			public const int OBJ_BRUSH = 2;

			public const int OBJ_DC = 3;

			public const int OBJ_ENHMETADC = 12;

			public const int OBJ_EXTPEN = 11;

			public const int OBJ_FONT = 6;

			public const int OBJ_MEMDC = 10;

			public const int OBJ_METADC = 4;

			public const int OBJ_METAFILE = 9;

			public const int OBJ_PAL = 5;

			public const int OBJ_PEN = 1;

			public const int OBJ_REGION = 8;

			public const int OBJID_CLIENT = -4;

			public const int OBJID_QUERYCLASSNAMEIDX = -12;

			public const int OBJID_WINDOW = 0;

			public const int ODS_CHECKED = 8;

			public const int ODS_COMBOBOXEDIT = 4096;

			public const int ODS_DEFAULT = 32;

			public const int ODS_DISABLED = 4;

			public const int ODS_FOCUS = 16;

			public const int ODS_GRAYED = 2;

			public const int ODS_HOTLIGHT = 64;

			public const int ODS_INACTIVE = 128;

			public const int ODS_NOACCEL = 256;

			public const int ODS_NOFOCUSRECT = 512;

			public const int ODS_SELECTED = 1;

			public const int OFN_ALLOWMULTISELECT = 512;

			public const int OFN_CREATEPROMPT = 8192;

			public const int OFN_ENABLEHOOK = 32;

			public const int OFN_ENABLESIZING = 8388608;

			public const int OFN_EXPLORER = 524288;

			public const int OFN_FILEMUSTEXIST = 4096;

			public const int OFN_HIDEREADONLY = 4;

			public const int OFN_NOCHANGEDIR = 8;

			public const int OFN_NODEREFERENCELINKS = 1048576;

			public const int OFN_NOVALIDATE = 256;

			public const int OFN_OVERWRITEPROMPT = 2;

			public const int OFN_PATHMUSTEXIST = 2048;

			public const int OFN_READONLY = 1;

			public const int OFN_SHOWHELP = 16;

			public const int OFN_USESHELLITEM = 16777216;

			public const int OLE_E_INVALIDRECT = -2147221491;

			public const int OLE_E_NOCONNECTION = -2147221500;

			public const int OLE_E_PROMPTSAVECANCELLED = -2147221492;

			public const int OLECLOSE_PROMPTSAVE = 2;

			public const int OLECLOSE_SAVEIFDIRTY = 0;

			public const int OLEIVERB_DISCARDUNDOSTATE = -6;

			public const int OLEIVERB_HIDE = -3;

			public const int OLEIVERB_INPLACEACTIVATE = -5;

			public const int OLEIVERB_PRIMARY = 0;

			public const int OLEIVERB_PROPERTIES = -7;

			public const int OLEIVERB_SHOW = -1;

			public const int OLEIVERB_UIACTIVATE = -4;

			public const int OLEMISC_ACTIVATEWHENVISIBLE = 256;

			public const int OLEMISC_ACTSLIKEBUTTON = 4096;

			public const int OLEMISC_INSIDEOUT = 128;

			public const int OLEMISC_RECOMPOSEONRESIZE = 1;

			public const int OLEMISC_SETCLIENTSITEFIRST = 131072;

			public const int OPAQUE = 2;

			public const int OUT_DEFAULT_PRECIS = 0;

			public const int OUT_TT_ONLY_PRECIS = 7;

			public const int OUT_TT_PRECIS = 4;

			public const int PAGE_READONLY = 2;

			public const int PAGE_READWRITE = 4;

			public const int PAGE_WRITECOPY = 8;

			public const int PATCOPY = 15728673;

			public const int PATINVERT = 5898313;

			public const int PBM_SETBARCOLOR = 1033;

			public const int PBM_SETBKCOLOR = 8193;

			public const int PBM_SETMARQUEE = 1034;

			public const int PBM_SETPOS = 1026;

			public const int PBM_SETRANGE = 1025;

			public const int PBM_SETRANGE32 = 1030;

			public const int PBM_SETSTEP = 1028;

			public const int PBS_MARQUEE = 8;

			public const int PBS_SMOOTH = 1;

			public const int PD_ALLPAGES = 0;

			public const int PD_COLLATE = 16;

			public const int PD_CURRENTPAGE = 4194304;

			public const int PD_DISABLEPRINTTOFILE = 524288;

			public const int PD_ENABLEPRINTHOOK = 4096;

			public const int PD_ENABLEPRINTTEMPLATE = 16384;

			public const int PD_ENABLEPRINTTEMPLATEHANDLE = 65536;

			public const int PD_ENABLESETUPHOOK = 8192;

			public const int PD_ENABLESETUPTEMPLATE = 32768;

			public const int PD_ENABLESETUPTEMPLATEHANDLE = 131072;

			public const int PD_EXCLUSIONFLAGS = 16777216;

			public const int PD_HIDEPRINTTOFILE = 1048576;

			public const int PD_NOCURRENTPAGE = 8388608;

			public const int PD_NONETWORKBUTTON = 2097152;

			public const int PD_NOPAGENUMS = 8;

			public const int PD_NOSELECTION = 4;

			public const int PD_NOWARNING = 128;

			public const int PD_PAGENUMS = 2;

			public const int PD_PRINTSETUP = 64;

			public const int PD_PRINTTOFILE = 32;

			public const int PD_RESULT_APPLY = 2;

			public const int PD_RESULT_CANCEL = 0;

			public const int PD_RESULT_PRINT = 1;

			public const int PD_RETURNDC = 256;

			public const int PD_RETURNDEFAULT = 1024;

			public const int PD_RETURNIC = 512;

			public const int PD_SELECTION = 1;

			public const int PD_SHOWHELP = 2048;

			public const int PD_USEDEVMODECOPIES = 262144;

			public const int PD_USEDEVMODECOPIESANDCOLLATE = 262144;

			public const int PD_USELARGETEMPLATE = 268435456;

			public const int PDERR_CREATEICFAILURE = 4106;

			public const int PDERR_DEFAULTDIFFERENT = 4108;

			public const int PDERR_DNDMMISMATCH = 4105;

			public const int PDERR_GETDEVMODEFAIL = 4101;

			public const int PDERR_INITFAILURE = 4102;

			public const int PDERR_LOADDRVFAILURE = 4100;

			public const int PDERR_NODEFAULTPRN = 4104;

			public const int PDERR_NODEVICES = 4103;

			public const int PDERR_PARSEFAILURE = 4098;

			public const int PDERR_PRINTERNOTFOUND = 4107;

			public const int PDERR_RETDEFFAILURE = 4099;

			public const int PDERR_SETUPFAILURE = 4097;

			public const int PLANES = 14;

			public const int PM_NOREMOVE = 0;

			public const int PM_NOYIELD = 2;

			public const int PM_REMOVE = 1;

			public const int PRF_CHECKVISIBLE = 1;

			public const int PRF_CHILDREN = 16;

			public const int PRF_CLIENT = 4;

			public const int PRF_ERASEBKGND = 8;

			public const int PRF_NONCLIENT = 2;

			public const int PS_DOT = 2;

			public const int PS_ENDCAP_SQUARE = 256;

			public const int PS_GEOMETRIC = 65536;

			public const int PS_INSIDEFRAME = 6;

			public const int PS_NULL = 5;

			public const int PS_SOLID = 0;

			public const int PSD_DISABLEMARGINS = 16;

			public const int PSD_DISABLEORIENTATION = 256;

			public const int PSD_DISABLEPAPER = 512;

			public const int PSD_DISABLEPRINTER = 32;

			public const int PSD_ENABLEPAGESETUPHOOK = 8192;

			public const int PSD_INHUNDREDTHSOFMILLIMETERS = 8;

			public const int PSD_MARGINS = 2;

			public const int PSD_MINMARGINS = 1;

			public const int PSD_NONETWORKBUTTON = 2097152;

			public const int PSD_SHOWHELP = 2048;

			public const int PSM_SETFINISHTEXTA = 1139;

			public const int PSM_SETFINISHTEXTW = 1145;

			public const int PSM_SETTITLEA = 1135;

			public const int PSM_SETTITLEW = 1144;

			public const int QS_ALLEVENTS = 191;

			public const int QS_ALLINPUT = 255;

			public const int QS_ALLPOSTMESSAGE = 256;

			public const int QS_HOTKEY = 128;

			public const int QS_INPUT = 7;

			public const int QS_KEY = 1;

			public const int QS_MOUSE = 6;

			public const int QS_MOUSEBUTTON = 4;

			public const int QS_MOUSEMOVE = 2;

			public const int QS_PAINT = 32;

			public const int QS_POSTMESSAGE = 8;

			public const int QS_SENDMESSAGE = 64;

			public const int QS_TIMER = 16;

			public const int R2_BLACK = 1;

			public const int R2_COPYPEN = 13;

			public const int R2_MASKNOTPEN = 3;

			public const int R2_MASKPEN = 9;

			public const int R2_MASKPENNOT = 5;

			public const int R2_MERGENOTPEN = 12;

			public const int R2_MERGEPEN = 15;

			public const int R2_MERGEPENNOT = 14;

			public const int R2_NOP = 11;

			public const int R2_NOT = 6;

			public const int R2_NOTCOPYPEN = 4;

			public const int R2_NOTMASKPEN = 8;

			public const int R2_NOTMERGEPEN = 2;

			public const int R2_NOTXORPEN = 10;

			public const int R2_WHITE = 16;

			public const int R2_XORPEN = 7;

			public const int RB_INSERTBANDA = 1025;

			public const int RB_INSERTBANDW = 1034;

			public const int RDW_ALLCHILDREN = 128;

			public const int RDW_ERASE = 4;

			public const int RDW_ERASENOW = 512;

			public const int RDW_FRAME = 1024;

			public const int RDW_INVALIDATE = 1;

			public const int RDW_UPDATENOW = 256;

			public const int RECO_DROP = 1;

			public const int RGN_AND = 1;

			public const int RGN_DIFF = 4;

			public const int RGN_XOR = 3;

			public const int RPC_E_CANTCALLOUT_ININPUTSYNCCALL = -2147417843;

			public const int RPC_E_CHANGED_MODE = -2147417850;

			public const int S_FALSE = 1;

			public const int S_OK = 0;

			public const int SB_BOTTOM = 7;

			public const int SB_CTL = 2;

			public const int SB_ENDSCROLL = 8;

			public const int SB_GETRECT = 1034;

			public const int SB_GETTEXTA = 1026;

			public const int SB_GETTEXTLENGTHA = 1027;

			public const int SB_GETTEXTLENGTHW = 1036;

			public const int SB_GETTEXTW = 1037;

			public const int SB_GETTIPTEXTA = 1042;

			public const int SB_GETTIPTEXTW = 1043;

			public const int SB_HORZ = 0;

			public const int SB_LEFT = 6;

			public const int SB_LINEDOWN = 1;

			public const int SB_LINELEFT = 0;

			public const int SB_LINERIGHT = 1;

			public const int SB_LINEUP = 0;

			public const int SB_PAGEDOWN = 3;

			public const int SB_PAGELEFT = 2;

			public const int SB_PAGERIGHT = 3;

			public const int SB_PAGEUP = 2;

			public const int SB_RIGHT = 7;

			public const int SB_SETICON = 1039;

			public const int SB_SETPARTS = 1028;

			public const int SB_SETTEXTA = 1025;

			public const int SB_SETTEXTW = 1035;

			public const int SB_SETTIPTEXTA = 1040;

			public const int SB_SETTIPTEXTW = 1041;

			public const int SB_SIMPLE = 1033;

			public const int SB_THUMBPOSITION = 4;

			public const int SB_THUMBTRACK = 5;

			public const int SB_TOP = 6;

			public const int SB_VERT = 1;

			public const int SBARS_SIZEGRIP = 256;

			public const int SBS_HORZ = 0;

			public const int SBS_VERT = 1;

			public const int SBT_NOBORDERS = 256;

			public const int SBT_OWNERDRAW = 4096;

			public const int SBT_POPOUT = 512;

			public const int SBT_RTLREADING = 1024;

			public const int SC_CLOSE = 61536;

			public const int SC_CONTEXTHELP = 61824;

			public const int SC_KEYMENU = 61696;

			public const int SC_MAXIMIZE = 61488;

			public const int SC_MINIMIZE = 61472;

			public const int SC_MOVE = 61456;

			public const int SC_RESTORE = 61728;

			public const int SC_SIZE = 61440;

			public const int SHGFI_ADDOVERLAYS = 32;

			public const int SHGFI_ATTR_SPECIFIED = 131072;

			public const int SHGFI_ATTRIBUTES = 2048;

			public const int SHGFI_DISPLAYNAME = 512;

			public const int SHGFI_EXETYPE = 8192;

			public const int SHGFI_ICON = 256;

			public const int SHGFI_ICONLOCATION = 4096;

			public const int SHGFI_LARGEICON = 0;

			public const int SHGFI_LINKOVERLAY = 32768;

			public const int SHGFI_OPENICON = 2;

			public const int SHGFI_OVERLAYINDEX = 64;

			public const int SHGFI_PIDL = 8;

			public const int SHGFI_SELECTED = 65536;

			public const int SHGFI_SHELLICONSIZE = 4;

			public const int SHGFI_SMALLICON = 1;

			public const int SHGFI_SYSICONINDEX = 16384;

			public const int SHGFI_TYPENAME = 1024;

			public const int SHGFI_USEFILEATTRIBUTES = 16;

			public const int SHGFP_TYPE_CURRENT = 0;

			public const int SIF_ALL = 23;

			public const int SIF_PAGE = 2;

			public const int SIF_POS = 4;

			public const int SIF_RANGE = 1;

			public const int SIF_TRACKPOS = 16;

			public const int SIZE_MAXIMIZED = 2;

			public const int SIZE_RESTORED = 0;

			public const int SM_ARRANGE = 56;

			public const int SM_CLEANBOOT = 67;

			public const int SM_CMONITORS = 80;

			public const int SM_CMOUSEBUTTONS = 43;

			public const int SM_CXBORDER = 5;

			public const int SM_CXCURSOR = 13;

			public const int SM_CXDOUBLECLK = 36;

			public const int SM_CXDRAG = 68;

			public const int SM_CXEDGE = 45;

			public const int SM_CXFIXEDFRAME = 7;

			public const int SM_CXFOCUSBORDER = 83;

			public const int SM_CXFRAME = 32;

			public const int SM_CXHSCROLL = 21;

			public const int SM_CXHTHUMB = 10;

			public const int SM_CXICON = 11;

			public const int SM_CXICONSPACING = 38;

			public const int SM_CXMAXIMIZED = 61;

			public const int SM_CXMAXTRACK = 59;

			public const int SM_CXMENUCHECK = 71;

			public const int SM_CXMENUSIZE = 54;

			public const int SM_CXMIN = 28;

			public const int SM_CXMINIMIZED = 57;

			public const int SM_CXMINSPACING = 47;

			public const int SM_CXMINTRACK = 34;

			public const int SM_CXSCREEN = 0;

			public const int SM_CXSIZE = 30;

			public const int SM_CXSIZEFRAME = 32;

			public const int SM_CXSMICON = 49;

			public const int SM_CXSMSIZE = 52;

			public const int SM_CXVIRTUALSCREEN = 78;

			public const int SM_CXVSCROLL = 2;

			public const int SM_CYBORDER = 6;

			public const int SM_CYCAPTION = 4;

			public const int SM_CYCURSOR = 14;

			public const int SM_CYDOUBLECLK = 37;

			public const int SM_CYDRAG = 69;

			public const int SM_CYEDGE = 46;

			public const int SM_CYFIXEDFRAME = 8;

			public const int SM_CYFOCUSBORDER = 84;

			public const int SM_CYFRAME = 33;

			public const int SM_CYHSCROLL = 3;

			public const int SM_CYICON = 12;

			public const int SM_CYICONSPACING = 39;

			public const int SM_CYKANJIWINDOW = 18;

			public const int SM_CYMAXIMIZED = 62;

			public const int SM_CYMAXTRACK = 60;

			public const int SM_CYMENU = 15;

			public const int SM_CYMENUCHECK = 72;

			public const int SM_CYMENUSIZE = 55;

			public const int SM_CYMIN = 29;

			public const int SM_CYMINIMIZED = 58;

			public const int SM_CYMINSPACING = 48;

			public const int SM_CYMINTRACK = 35;

			public const int SM_CYSCREEN = 1;

			public const int SM_CYSIZE = 31;

			public const int SM_CYSIZEFRAME = 33;

			public const int SM_CYSMCAPTION = 51;

			public const int SM_CYSMICON = 50;

			public const int SM_CYSMSIZE = 53;

			public const int SM_CYVIRTUALSCREEN = 79;

			public const int SM_CYVSCROLL = 20;

			public const int SM_CYVTHUMB = 9;

			public const int SM_DBCSENABLED = 42;

			public const int SM_DEBUG = 22;

			public const int SM_MENUDROPALIGNMENT = 40;

			public const int SM_MIDEASTENABLED = 74;

			public const int SM_MOUSEPRESENT = 19;

			public const int SM_MOUSEWHEELPRESENT = 75;

			public const int SM_NETWORK = 63;

			public const int SM_PENWINDOWS = 41;

			public const int SM_REMOTESESSION = 4096;

			public const int SM_SAMEDISPLAYFORMAT = 81;

			public const int SM_SECURE = 44;

			public const int SM_SHOWSOUNDS = 70;

			public const int SM_SWAPBUTTON = 23;

			public const int SM_XVIRTUALSCREEN = 76;

			public const int SM_YVIRTUALSCREEN = 77;

			public const int SORT_DEFAULT = 0;

			public const int SPI_GETACTIVEWINDOWTRACKING = 4096;

			public const int SPI_GETACTIVEWNDTRKTIMEOUT = 8194;

			public const int SPI_GETANIMATION = 72;

			public const int SPI_GETBORDER = 5;

			public const int SPI_GETCARETWIDTH = 8198;

			public const int SPI_GETCOMBOBOXANIMATION = 4100;

			public const int SPI_GETDEFAULTINPUTLANG = 89;

			public const int SPI_GETDRAGFULLWINDOWS = 38;

			public const int SPI_GETDROPSHADOW = 4132;

			public const int SPI_GETFLATMENU = 4130;

			public const int SPI_GETFONTSMOOTHING = 74;

			public const int SPI_GETFONTSMOOTHINGCONTRAST = 8204;

			public const int SPI_GETFONTSMOOTHINGTYPE = 8202;

			public const int SPI_GETGRADIENTCAPTIONS = 4104;

			public const int SPI_GETHIGHCONTRAST = 66;

			public const int SPI_GETHOTTRACKING = 4110;

			public const int SPI_GETICONTITLELOGFONT = 31;

			public const int SPI_GETICONTITLEWRAP = 25;

			public const int SPI_GETKEYBOARDCUES = 4106;

			public const int SPI_GETKEYBOARDDELAY = 22;

			public const int SPI_GETKEYBOARDPREF = 68;

			public const int SPI_GETKEYBOARDSPEED = 10;

			public const int SPI_GETLISTBOXSMOOTHSCROLLING = 4102;

			public const int SPI_GETMENUANIMATION = 4098;

			public const int SPI_GETMENUDROPALIGNMENT = 27;

			public const int SPI_GETMENUFADE = 4114;

			public const int SPI_GETMENUSHOWDELAY = 106;

			public const int SPI_GETMOUSEHOVERHEIGHT = 100;

			public const int SPI_GETMOUSEHOVERTIME = 102;

			public const int SPI_GETMOUSEHOVERWIDTH = 98;

			public const int SPI_GETMOUSESPEED = 112;

			public const int SPI_GETNONCLIENTMETRICS = 41;

			public const int SPI_GETSELECTIONFADE = 4116;

			public const int SPI_GETSNAPTODEFBUTTON = 95;

			public const int SPI_GETTOOLTIPANIMATION = 4118;

			public const int SPI_GETUIEFFECTS = 4158;

			public const int SPI_GETWHEELSCROLLLINES = 104;

			public const int SPI_GETWORKAREA = 48;

			public const int SPI_ICONHORIZONTALSPACING = 13;

			public const int SPI_ICONVERTICALSPACING = 24;

			public const int SRCAND = 8913094;

			public const int SRCCOPY = 13369376;

			public const int SRCPAINT = 15597702;

			public const int SS_CENTER = 1;

			public const int SS_LEFT = 0;

			public const int SS_NOPREFIX = 128;

			public const int SS_OWNERDRAW = 13;

			public const int SS_RIGHT = 2;

			public const int SS_SUNKEN = 4096;

			public const int STAP_ALLOW_CONTROLS = 2;

			public const int STAP_ALLOW_NONCLIENT = 1;

			public const int STAP_ALLOW_WEBCONTENT = 4;

			public const int STARTF_USESHOWWINDOW = 1;

			public const int STATFLAG_DEFAULT = 0;

			public const int STATFLAG_NONAME = 1;

			public const int STATFLAG_NOOPEN = 2;

			public const int STATUS_PENDING = 259;

			public const int stc4 = 1091;

			public const int STG_E_ACCESSDENIED = -2147287035;

			public const int STG_E_DISKISWRITEPROTECTED = -2147287021;

			public const int STG_E_FILENOTFOUND = -2147287038;

			public const int STG_E_INSUFFICIENTMEMORY = -2147287032;

			public const int STG_E_INVALIDFUNCTION = -2147287039;

			public const int STG_E_INVALIDHANDLE = -2147287034;

			public const int STG_E_INVALIDPOINTER = -2147287031;

			public const int STG_E_LOCKVIOLATION = -2147287007;

			public const int STG_E_NOMOREFILES = -2147287022;

			public const int STG_E_PATHNOTFOUND = -2147287037;

			public const int STG_E_READFAULT = -2147287010;

			public const int STG_E_SEEKERROR = -2147287015;

			public const int STG_E_SHAREVIOLATION = -2147287008;

			public const int STG_E_TOOMANYOPENFILES = -2147287036;

			public const int STG_E_WRITEFAULT = -2147287011;

			public const int STGC_DANGEROUSLYCOMMITMERELYTODISKCACHE = 4;

			public const int STGC_DEFAULT = 0;

			public const int STGC_ONLYIFCURRENT = 2;

			public const int STGC_OVERWRITE = 1;

			public const int STGM_CONVERT = 131072;

			public const int STGM_CREATE = 4096;

			public const int STGM_DELETEONRELEASE = 67108864;

			public const int STGM_READ = 0;

			public const int STGM_READWRITE = 2;

			public const int STGM_SHARE_EXCLUSIVE = 16;

			public const int STGM_TRANSACTED = 65536;

			public const int STGM_WRITE = 1;

			public const uint STILL_ACTIVE = 259u;

			public const int STREAM_SEEK_CUR = 1;

			public const int STREAM_SEEK_END = 2;

			public const int STREAM_SEEK_SET = 0;

			public const int SUBLANG_DEFAULT = 1;

			public const int SW_ERASE = 4;

			public const int SW_HIDE = 0;

			public const int SW_INVALIDATE = 2;

			public const int SW_MAX = 10;

			public const int SW_MAXIMIZE = 3;

			public const int SW_MINIMIZE = 6;

			public const int SW_NORMAL = 1;

			public const int SW_RESTORE = 9;

			public const int SW_SCROLLCHILDREN = 1;

			public const int SW_SHOW = 5;

			public const int SW_SHOWMAXIMIZED = 3;

			public const int SW_SHOWMINIMIZED = 2;

			public const int SW_SHOWMINNOACTIVE = 7;

			public const int SW_SHOWNA = 8;

			public const int SW_SHOWNOACTIVATE = 4;

			public const int SW_SMOOTHSCROLL = 16;

			public const int SWP_DRAWFRAME = 32;

			public const int SWP_HIDEWINDOW = 128;

			public const int SWP_NOACTIVATE = 16;

			public const int SWP_NOMOVE = 2;

			public const int SWP_NOOWNERZORDER = 512;

			public const int SWP_NOSIZE = 1;

			public const int SWP_NOZORDER = 4;

			public const int SWP_SHOWWINDOW = 64;

			public const int TA_DEFAULT = 0;

			public const int TB_ADDBUTTONSA = 1044;

			public const int TB_ADDBUTTONSW = 1092;

			public const int TB_ADDSTRINGA = 1052;

			public const int TB_ADDSTRINGW = 1101;

			public const int TB_AUTOSIZE = 1057;

			public const int TB_BOTTOM = 7;

			public const int TB_BUTTONSTRUCTSIZE = 1054;

			public const int TB_DELETEBUTTON = 1046;

			public const int TB_ENABLEBUTTON = 1025;

			public const int TB_ENDTRACK = 8;

			public const int TB_GETBUTTON = 1047;

			public const int TB_GETBUTTONINFOA = 1089;

			public const int TB_GETBUTTONINFOW = 1087;

			public const int TB_GETBUTTONSIZE = 1082;

			public const int TB_GETBUTTONTEXTA = 1069;

			public const int TB_GETBUTTONTEXTW = 1099;

			public const int TB_GETRECT = 1075;

			public const int TB_GETROWS = 1064;

			public const int TB_GETTOOLTIPS = 1059;

			public const int TB_INSERTBUTTONA = 1045;

			public const int TB_INSERTBUTTONW = 1091;

			public const int TB_ISBUTTONCHECKED = 1034;

			public const int TB_ISBUTTONINDETERMINATE = 1037;

			public const int TB_LINEDOWN = 1;

			public const int TB_LINEUP = 0;

			public const int TB_MAPACCELERATORA = 1102;

			public const int TB_MAPACCELERATORW = 1114;

			public const int TB_PAGEDOWN = 3;

			public const int TB_PAGEUP = 2;

			public const int TB_SAVERESTOREA = 1050;

			public const int TB_SAVERESTOREW = 1100;

			public const int TB_SETBUTTONINFOA = 1090;

			public const int TB_SETBUTTONINFOW = 1088;

			public const int TB_SETBUTTONSIZE = 1055;

			public const int TB_SETEXTENDEDSTYLE = 1108;

			public const int TB_SETIMAGELIST = 1072;

			public const int TB_SETTOOLTIPS = 1060;

			public const int TB_THUMBPOSITION = 4;

			public const int TB_THUMBTRACK = 5;

			public const int TB_TOP = 6;

			public const int TBIF_COMMAND = 32;

			public const int TBIF_IMAGE = 1;

			public const int TBIF_SIZE = 64;

			public const int TBIF_STATE = 4;

			public const int TBIF_STYLE = 8;

			public const int TBIF_TEXT = 2;

			public const int TBM_GETPOS = 1024;

			public const int TBM_SETLINESIZE = 1047;

			public const int TBM_SETPAGESIZE = 1045;

			public const int TBM_SETPOS = 1029;

			public const int TBM_SETRANGE = 1030;

			public const int TBM_SETRANGEMAX = 1032;

			public const int TBM_SETRANGEMIN = 1031;

			public const int TBM_SETTIC = 1028;

			public const int TBM_SETTICFREQ = 1044;

			public const int TBN_DROPDOWN = -710;

			public const int TBN_GETBUTTONINFOA = -700;

			public const int TBN_GETBUTTONINFOW = -720;

			public const int TBN_GETDISPINFOA = -716;

			public const int TBN_GETDISPINFOW = -717;

			public const int TBN_GETINFOTIPA = -718;

			public const int TBN_GETINFOTIPW = -719;

			public const int TBN_HOTITEMCHANGE = -713;

			public const int TBN_QUERYINSERT = -706;

			public const int TBS_AUTOTICKS = 1;

			public const int TBS_BOTH = 8;

			public const int TBS_BOTTOM = 0;

			public const int TBS_NOTICKS = 16;

			public const int TBS_TOP = 4;

			public const int TBS_VERT = 2;

			public const int TBSTATE_CHECKED = 1;

			public const int TBSTATE_ENABLED = 4;

			public const int TBSTATE_HIDDEN = 8;

			public const int TBSTATE_INDETERMINATE = 16;

			public const int TBSTYLE_BUTTON = 0;

			public const int TBSTYLE_CHECK = 2;

			public const int TBSTYLE_DROPDOWN = 8;

			public const int TBSTYLE_EX_DRAWDDARROWS = 1;

			public const int TBSTYLE_FLAT = 2048;

			public const int TBSTYLE_LIST = 4096;

			public const int TBSTYLE_SEP = 1;

			public const int TBSTYLE_TOOLTIPS = 256;

			public const int TBSTYLE_WRAPPABLE = 512;

			public const int TCIF_IMAGE = 2;

			public const int TCIF_TEXT = 1;

			public const int TCM_ADJUSTRECT = 4904;

			public const int TCM_DELETEALLITEMS = 4873;

			public const int TCM_DELETEITEM = 4872;

			public const int TCM_GETCURSEL = 4875;

			public const int TCM_GETITEMA = 4869;

			public const int TCM_GETITEMRECT = 4874;

			public const int TCM_GETITEMW = 4924;

			public const int TCM_GETROWCOUNT = 4908;

			public const int TCM_GETTOOLTIPS = 4909;

			public const int TCM_INSERTITEMA = 4871;

			public const int TCM_INSERTITEMW = 4926;

			public const int TCM_SETCURSEL = 4876;

			public const int TCM_SETIMAGELIST = 4867;

			public const int TCM_SETITEMA = 4870;

			public const int TCM_SETITEMSIZE = 4905;

			public const int TCM_SETITEMW = 4925;

			public const int TCM_SETPADDING = 4907;

			public const int TCM_SETTOOLTIPS = 4910;

			public const int TCN_SELCHANGE = -551;

			public const int TCN_SELCHANGING = -552;

			public const int TCS_BOTTOM = 2;

			public const int TCS_BUTTONS = 256;

			public const int TCS_FIXEDWIDTH = 1024;

			public const int TCS_FLATBUTTONS = 8;

			public const int TCS_HOTTRACK = 64;

			public const int TCS_MULTILINE = 512;

			public const int TCS_OWNERDRAWFIXED = 8192;

			public const int TCS_RAGGEDRIGHT = 2048;

			public const int TCS_RIGHT = 2;

			public const int TCS_RIGHTJUSTIFY = 0;

			public const int TCS_TABS = 0;

			public const int TCS_TOOLTIPS = 16384;

			public const int TCS_VERTICAL = 128;

			public const int TME_HOVER = 1;

			public const int TME_LEAVE = 2;

			public const int TMPF_FIXED_PITCH = 1;

			public const string TOOLTIPS_CLASS = "tooltips_class32";

			public const int TPM_LEFTALIGN = 0;

			public const int TPM_LEFTBUTTON = 0;

			public const int TPM_RIGHTALIGN = 8;

			public const int TPM_RIGHTBUTTON = 2;

			public const int TPM_VERTICAL = 64;

			public const int TRANSPARENT = 1;

			public const int TTDT_AUTOMATIC = 0;

			public const int TTDT_AUTOPOP = 2;

			public const int TTDT_INITIAL = 3;

			public const int TTDT_RESHOW = 1;

			public const int TTF_ABSOLUTE = 128;

			public const int TTF_CENTERTIP = 2;

			public const int TTF_IDISHWND = 1;

			public const int TTF_RTLREADING = 4;

			public const int TTF_SUBCLASS = 16;

			public const int TTF_TRACK = 32;

			public const int TTF_TRANSPARENT = 256;

			public const int TTI_WARNING = 2;

			public const int TTM_ACTIVATE = 1025;

			public const int TTM_ADDTOOLA = 1028;

			public const int TTM_ADDTOOLW = 1074;

			public const int TTM_ADJUSTRECT = 1055;

			public const int TTM_DELTOOLA = 1029;

			public const int TTM_DELTOOLW = 1075;

			public const int TTM_ENUMTOOLSA = 1038;

			public const int TTM_ENUMTOOLSW = 1082;

			public const int TTM_GETCURRENTTOOLA = 1039;

			public const int TTM_GETCURRENTTOOLW = 1083;

			public const int TTM_GETDELAYTIME = 1045;

			public const int TTM_GETTEXTA = 1035;

			public const int TTM_GETTEXTW = 1080;

			public const int TTM_GETTIPBKCOLOR = 1046;

			public const int TTM_GETTIPTEXTCOLOR = 1047;

			public const int TTM_GETTOOLINFOA = 1032;

			public const int TTM_GETTOOLINFOW = 1077;

			public const int TTM_HITTESTA = 1034;

			public const int TTM_HITTESTW = 1079;

			public const int TTM_NEWTOOLRECTA = 1030;

			public const int TTM_NEWTOOLRECTW = 1076;

			public const int TTM_POP = 1052;

			public const int TTM_RELAYEVENT = 1031;

			public const int TTM_SETDELAYTIME = 1027;

			public const int TTM_SETMAXTIPWIDTH = 1048;

			public const int TTM_SETTIPBKCOLOR = 1043;

			public const int TTM_SETTIPTEXTCOLOR = 1044;

			public const int TTM_SETTITLEA = 1056;

			public const int TTM_SETTITLEW = 1057;

			public const int TTM_SETTOOLINFOA = 1033;

			public const int TTM_SETTOOLINFOW = 1078;

			public const int TTM_TRACKACTIVATE = 1041;

			public const int TTM_TRACKPOSITION = 1042;

			public const int TTM_UPDATE = 1053;

			public const int TTM_UPDATETIPTEXTA = 1036;

			public const int TTM_UPDATETIPTEXTW = 1081;

			public const int TTM_WINDOWFROMPOINT = 1040;

			public const int TTN_GETDISPINFOA = -520;

			public const int TTN_GETDISPINFOW = -530;

			public const int TTN_NEEDTEXTA = -520;

			public const int TTN_NEEDTEXTW = -530;

			public const int TTN_POP = -522;

			public const int TTN_SHOW = -521;

			public const int TTS_ALWAYSTIP = 1;

			public const int TTS_BALLOON = 64;

			public const int TTS_NOANIMATE = 16;

			public const int TTS_NOFADE = 32;

			public const int TTS_NOPREFIX = 2;

			public const int TV_FIRST = 4352;

			public const int TVC_BYKEYBOARD = 2;

			public const int TVC_BYMOUSE = 1;

			public const int TVC_UNKNOWN = 0;

			public const int TVE_COLLAPSE = 1;

			public const int TVE_EXPAND = 2;

			public const int TVGN_CARET = 9;

			public const int TVGN_DROPHILITE = 8;

			public const int TVGN_FIRSTVISIBLE = 5;

			public const int TVGN_NEXT = 1;

			public const int TVGN_NEXTVISIBLE = 6;

			public const int TVGN_PREVIOUS = 2;

			public const int TVGN_PREVIOUSVISIBLE = 7;

			public const int TVHT_ABOVE = 256;

			public const int TVHT_BELOW = 512;

			public const int TVHT_NOWHERE = 1;

			public const int TVHT_ONITEM = 70;

			public const int TVHT_ONITEMBUTTON = 16;

			public const int TVHT_ONITEMICON = 2;

			public const int TVHT_ONITEMINDENT = 8;

			public const int TVHT_ONITEMLABEL = 4;

			public const int TVHT_ONITEMRIGHT = 32;

			public const int TVHT_ONITEMSTATEICON = 64;

			public const int TVHT_TOLEFT = 2048;

			public const int TVHT_TORIGHT = 1024;

			public const int TVI_FIRST = -65535;

			public const int TVI_ROOT = -65536;

			public const int TVIF_HANDLE = 16;

			public const int TVIF_IMAGE = 2;

			public const int TVIF_PARAM = 4;

			public const int TVIF_SELECTEDIMAGE = 32;

			public const int TVIF_STATE = 8;

			public const int TVIF_TEXT = 1;

			public const int TVIS_EXPANDED = 32;

			public const int TVIS_EXPANDEDONCE = 64;

			public const int TVIS_SELECTED = 2;

			public const int TVIS_STATEIMAGEMASK = 61440;

			public const int TVM_DELETEITEM = 4353;

			public const int TVM_EDITLABELA = 4366;

			public const int TVM_EDITLABELW = 4417;

			public const int TVM_ENDEDITLABELNOW = 4374;

			public const int TVM_ENSUREVISIBLE = 4372;

			public const int TVM_EXPAND = 4354;

			public const int TVM_GETEDITCONTROL = 4367;

			public const int TVM_GETINDENT = 4358;

			public const int TVM_GETISEARCHSTRINGA = 4375;

			public const int TVM_GETISEARCHSTRINGW = 4416;

			public const int TVM_GETITEMA = 4364;

			public const int TVM_GETITEMHEIGHT = 4380;

			public const int TVM_GETITEMRECT = 4356;

			public const int TVM_GETITEMW = 4414;

			public const int TVM_GETLINECOLOR = 4393;

			public const int TVM_GETNEXTITEM = 4362;

			public const int TVM_GETVISIBLECOUNT = 4368;

			public const int TVM_HITTEST = 4369;

			public const int TVM_INSERTITEMA = 4352;

			public const int TVM_INSERTITEMW = 4402;

			public const int TVM_SELECTITEM = 4363;

			public const int TVM_SETBKCOLOR = 4381;

			public const int TVM_SETIMAGELIST = 4361;

			public const int TVM_SETINDENT = 4359;

			public const int TVM_SETITEMA = 4365;

			public const int TVM_SETITEMHEIGHT = 4379;

			public const int TVM_SETITEMW = 4415;

			public const int TVM_SETLINECOLOR = 4392;

			public const int TVM_SETTEXTCOLOR = 4382;

			public const int TVM_SETTOOLTIPS = 4376;

			public const int TVM_SORTCHILDRENCB = 4373;

			public const int TVN_BEGINDRAGA = -407;

			public const int TVN_BEGINDRAGW = -456;

			public const int TVN_BEGINLABELEDITA = -410;

			public const int TVN_BEGINLABELEDITW = -459;

			public const int TVN_BEGINRDRAGA = -408;

			public const int TVN_BEGINRDRAGW = -457;

			public const int TVN_ENDLABELEDITA = -411;

			public const int TVN_ENDLABELEDITW = -460;

			public const int TVN_GETDISPINFOA = -403;

			public const int TVN_GETDISPINFOW = -452;

			public const int TVN_GETINFOTIPA = -413;

			public const int TVN_GETINFOTIPW = -414;

			public const int TVN_ITEMEXPANDEDA = -406;

			public const int TVN_ITEMEXPANDEDW = -455;

			public const int TVN_ITEMEXPANDINGA = -405;

			public const int TVN_ITEMEXPANDINGW = -454;

			public const int TVN_SELCHANGEDA = -402;

			public const int TVN_SELCHANGEDW = -451;

			public const int TVN_SELCHANGINGA = -401;

			public const int TVN_SELCHANGINGW = -450;

			public const int TVN_SETDISPINFOA = -404;

			public const int TVN_SETDISPINFOW = -453;

			public const int TVS_CHECKBOXES = 256;

			public const int TVS_EDITLABELS = 8;

			public const int TVS_FULLROWSELECT = 4096;

			public const int TVS_HASBUTTONS = 1;

			public const int TVS_HASLINES = 2;

			public const int TVS_INFOTIP = 2048;

			public const int TVS_LINESATROOT = 4;

			public const int TVS_NONEVENHEIGHT = 16384;

			public const int TVS_NOTOOLTIPS = 128;

			public const int TVS_RTLREADING = 64;

			public const int TVS_SHOWSELALWAYS = 32;

			public const int TVS_TRACKSELECT = 512;

			public const int TVSIL_STATE = 2;

			public const int TYMED_NULL = 0;

			public const int UIS_CLEAR = 2;

			public const int UIS_INITIALIZE = 3;

			public const int UIS_SET = 1;

			public const int UISF_HIDEACCEL = 2;

			public const int UISF_HIDEFOCUS = 1;

			public const int UOI_FLAGS = 1;

			public const int USERCLASSTYPE_APPNAME = 3;

			public const int USERCLASSTYPE_FULL = 1;

			public const int USERCLASSTYPE_SHORT = 2;

			public const string uuid_IAccessible = "{618736E0-3C3D-11CF-810C-00AA00389B71}";

			public const string uuid_IEnumVariant = "{00020404-0000-0000-C000-000000000046}";

			public const int VIEW_E_DRAW = -2147221184;

			public const int VK_CAPITAL = 20;

			public const int VK_CONTROL = 17;

			public const int VK_DELETE = 46;

			public const int VK_DOWN = 40;

			public const int VK_END = 35;

			public const int VK_ESCAPE = 27;

			public const int VK_HOME = 36;

			public const int VK_INSERT = 45;

			public const int VK_KANA = 21;

			public const int VK_LEFT = 37;

			public const int VK_MENU = 18;

			public const int VK_NEXT = 34;

			public const int VK_NUMLOCK = 144;

			public const int VK_PRIOR = 33;

			public const int VK_RIGHT = 39;

			public const int VK_SCROLL = 145;

			public const int VK_SHIFT = 16;

			public const int VK_TAB = 9;

			public const int VK_UP = 38;

			public const int WA_ACTIVE = 1;

			public const int WA_CLICKACTIVE = 2;

			public const int WA_INACTIVE = 0;

			public const string WC_DATETIMEPICK = "SysDateTimePick32";

			public const string WC_LISTVIEW = "SysListView32";

			public const string WC_MONTHCAL = "SysMonthCal32";

			public const string WC_PROGRESS = "msctls_progress32";

			public const string WC_STATUSBAR = "msctls_statusbar32";

			public const string WC_TABCONTROL = "SysTabControl32";

			public const string WC_TOOLBAR = "ToolbarWindow32";

			public const string WC_TRACKBAR = "msctls_trackbar32";

			public const string WC_TREEVIEW = "SysTreeView32";

			public const int WH_GETMESSAGE = 3;

			public const int WH_JOURNALPLAYBACK = 1;

			public const int WH_MOUSE = 7;

			public const int WHEEL_DELTA = 120;

			public const int WINDING = 2;

			public const int WM_ACTIVATE = 6;

			public const int WM_ACTIVATEAPP = 28;

			public const int WM_AFXFIRST = 864;

			public const int WM_AFXLAST = 895;

			public const int WM_APP = 32768;

			public const int WM_ASKCBFORMATNAME = 780;

			public const int WM_CANCELJOURNAL = 75;

			public const int WM_CANCELMODE = 31;

			public const int WM_CAPTURECHANGED = 533;

			public const int WM_CHANGECBCHAIN = 781;

			public const int WM_CHANGEUISTATE = 295;

			public const int WM_CHAR = 258;

			public const int WM_CHARTOITEM = 47;

			public const int WM_CHILDACTIVATE = 34;

			public const int WM_CHOOSEFONT_GETLOGFONT = 1025;

			public const int WM_CLEAR = 771;

			public const int WM_CLOSE = 16;

			public const int WM_COMMAND = 273;

			public const int WM_COMMNOTIFY = 68;

			public const int WM_COMPACTING = 65;

			public const int WM_COMPAREITEM = 57;

			public const int WM_CONTEXTMENU = 123;

			public const int WM_COPY = 769;

			public const int WM_COPYDATA = 74;

			public const int WM_CREATE = 1;

			public const int WM_CTLCOLOR = 25;

			public const int WM_CTLCOLORBTN = 309;

			public const int WM_CTLCOLORDLG = 310;

			public const int WM_CTLCOLOREDIT = 307;

			public const int WM_CTLCOLORLISTBOX = 308;

			public const int WM_CTLCOLORMSGBOX = 306;

			public const int WM_CTLCOLORSCROLLBAR = 311;

			public const int WM_CTLCOLORSTATIC = 312;

			public const int WM_CUT = 768;

			public const int WM_DEADCHAR = 259;

			public const int WM_DELETEITEM = 45;

			public const int WM_DESTROY = 2;

			public const int WM_DESTROYCLIPBOARD = 775;

			public const int WM_DEVICECHANGE = 537;

			public const int WM_DEVMODECHANGE = 27;

			public const int WM_DISPLAYCHANGE = 126;

			public const int WM_DRAWCLIPBOARD = 776;

			public const int WM_DRAWITEM = 43;

			public const int WM_DROPFILES = 563;

			public const int WM_ENABLE = 10;

			public const int WM_ENDSESSION = 22;

			public const int WM_ENTERIDLE = 289;

			public const int WM_ENTERMENULOOP = 529;

			public const int WM_ENTERSIZEMOVE = 561;

			public const int WM_ERASEBKGND = 20;

			public const int WM_EXITMENULOOP = 530;

			public const int WM_EXITSIZEMOVE = 562;

			public const int WM_FONTCHANGE = 29;

			public const int WM_GETDLGCODE = 135;

			public const int WM_GETFONT = 49;

			public const int WM_GETHOTKEY = 51;

			public const int WM_GETICON = 127;

			public const int WM_GETMINMAXINFO = 36;

			public const int WM_GETOBJECT = 61;

			public const int WM_GETTEXT = 13;

			public const int WM_GETTEXTLENGTH = 14;

			public const int WM_HANDHELDFIRST = 856;

			public const int WM_HANDHELDLAST = 863;

			public const int WM_HELP = 83;

			public const int WM_HOTKEY = 786;

			public const int WM_HSCROLL = 276;

			public const int WM_HSCROLLCLIPBOARD = 782;

			public const int WM_ICONERASEBKGND = 39;

			public const int WM_IME_CHAR = 646;

			public const int WM_IME_COMPOSITION = 271;

			public const int WM_IME_COMPOSITIONFULL = 644;

			public const int WM_IME_CONTROL = 643;

			public const int WM_IME_ENDCOMPOSITION = 270;

			public const int WM_IME_KEYDOWN = 656;

			public const int WM_IME_KEYLAST = 271;

			public const int WM_IME_KEYUP = 657;

			public const int WM_IME_NOTIFY = 642;

			public const int WM_IME_SELECT = 645;

			public const int WM_IME_SETCONTEXT = 641;

			public const int WM_IME_STARTCOMPOSITION = 269;

			public const int WM_INITDIALOG = 272;

			public const int WM_INITMENU = 278;

			public const int WM_INITMENUPOPUP = 279;

			public const int WM_INPUTLANGCHANGE = 81;

			public const int WM_INPUTLANGCHANGEREQUEST = 80;

			public const int WM_KEYDOWN = 256;

			public const int WM_KEYFIRST = 256;

			public const int WM_KEYLAST = 264;

			public const int WM_KEYUP = 257;

			public const int WM_KILLFOCUS = 8;

			public const int WM_LBUTTONDBLCLK = 515;

			public const int WM_LBUTTONDOWN = 513;

			public const int WM_LBUTTONUP = 514;

			public const int WM_MBUTTONDBLCLK = 521;

			public const int WM_MBUTTONDOWN = 519;

			public const int WM_MBUTTONUP = 520;

			public const int WM_MDIACTIVATE = 546;

			public const int WM_MDICASCADE = 551;

			public const int WM_MDICREATE = 544;

			public const int WM_MDIDESTROY = 545;

			public const int WM_MDIGETACTIVE = 553;

			public const int WM_MDIICONARRANGE = 552;

			public const int WM_MDIMAXIMIZE = 549;

			public const int WM_MDINEXT = 548;

			public const int WM_MDIREFRESHMENU = 564;

			public const int WM_MDIRESTORE = 547;

			public const int WM_MDISETMENU = 560;

			public const int WM_MDITILE = 550;

			public const int WM_MEASUREITEM = 44;

			public const int WM_MENUCHAR = 288;

			public const int WM_MENUSELECT = 287;

			public const int WM_MOUSEACTIVATE = 33;

			public const int WM_MOUSEFIRST = 512;

			public const int WM_MOUSEHOVER = 673;

			public const int WM_MOUSELAST = 522;

			public const int WM_MOUSELEAVE = 675;

			public const int WM_MOUSEMOVE = 512;

			public const int WM_MOUSEWHEEL = 522;

			public const int WM_MOVE = 3;

			public const int WM_MOVING = 534;

			public const int WM_NCACTIVATE = 134;

			public const int WM_NCCALCSIZE = 131;

			public const int WM_NCCREATE = 129;

			public const int WM_NCDESTROY = 130;

			public const int WM_NCHITTEST = 132;

			public const int WM_NCLBUTTONDBLCLK = 163;

			public const int WM_NCLBUTTONDOWN = 161;

			public const int WM_NCLBUTTONUP = 162;

			public const int WM_NCMBUTTONDBLCLK = 169;

			public const int WM_NCMBUTTONDOWN = 167;

			public const int WM_NCMBUTTONUP = 168;

			public const int WM_NCMOUSELEAVE = 674;

			public const int WM_NCMOUSEMOVE = 160;

			public const int WM_NCPAINT = 133;

			public const int WM_NCRBUTTONDBLCLK = 166;

			public const int WM_NCRBUTTONDOWN = 164;

			public const int WM_NCRBUTTONUP = 165;

			public const int WM_NCXBUTTONDBLCLK = 173;

			public const int WM_NCXBUTTONDOWN = 171;

			public const int WM_NCXBUTTONUP = 172;

			public const int WM_NEXTDLGCTL = 40;

			public const int WM_NEXTMENU = 531;

			public const int WM_NOTIFY = 78;

			public const int WM_NOTIFYFORMAT = 85;

			public const int WM_NULL = 0;

			public const int WM_PAINT = 15;

			public const int WM_PAINTCLIPBOARD = 777;

			public const int WM_PAINTICON = 38;

			public const int WM_PALETTECHANGED = 785;

			public const int WM_PALETTEISCHANGING = 784;

			public const int WM_PARENTNOTIFY = 528;

			public const int WM_PASTE = 770;

			public const int WM_PENWINFIRST = 896;

			public const int WM_PENWINLAST = 911;

			public const int WM_POWER = 72;

			public const int WM_POWERBROADCAST = 536;

			public const int WM_PRINT = 791;

			public const int WM_PRINTCLIENT = 792;

			public const int WM_QUERYDRAGICON = 55;

			public const int WM_QUERYENDSESSION = 17;

			public const int WM_QUERYNEWPALETTE = 783;

			public const int WM_QUERYOPEN = 19;

			public const int WM_QUERYUISTATE = 297;

			public const int WM_QUEUESYNC = 35;

			public const int WM_QUIT = 18;

			public const int WM_RBUTTONDBLCLK = 518;

			public const int WM_RBUTTONDOWN = 516;

			public const int WM_RBUTTONUP = 517;

			public const int WM_REFLECT = 8192;

			public const int WM_RENDERALLFORMATS = 774;

			public const int WM_RENDERFORMAT = 773;

			public const int WM_SETCURSOR = 32;

			public const int WM_SETFOCUS = 7;

			public const int WM_SETFONT = 48;

			public const int WM_SETHOTKEY = 50;

			public const int WM_SETICON = 128;

			public const int WM_SETREDRAW = 11;

			public const int WM_SETTEXT = 12;

			public const int WM_SETTINGCHANGE = 26;

			public const int WM_SHOWWINDOW = 24;

			public const int WM_SIZE = 5;

			public const int WM_SIZECLIPBOARD = 779;

			public const int WM_SIZING = 532;

			public const int WM_SPOOLERSTATUS = 42;

			public const int WM_STYLECHANGED = 125;

			public const int WM_STYLECHANGING = 124;

			public const int WM_SYSCHAR = 262;

			public const int WM_SYSCOLORCHANGE = 21;

			public const int WM_SYSCOMMAND = 274;

			public const int WM_SYSDEADCHAR = 263;

			public const int WM_SYSKEYDOWN = 260;

			public const int WM_SYSKEYUP = 261;

			public const int WM_TCARD = 82;

			public const int WM_THEMECHANGED = 794;

			public const int WM_TIMECHANGE = 30;

			public const int WM_TIMER = 275;

			public const int WM_UNDO = 772;

			public const int WM_UNINITMENUPOPUP = 293;

			public const int WM_UPDATEUISTATE = 296;

			public const int WM_USER = 1024;

			public const int WM_USERCHANGED = 84;

			public const int WM_VKEYTOITEM = 46;

			public const int WM_VSCROLL = 277;

			public const int WM_VSCROLLCLIPBOARD = 778;

			public const int WM_WINDOWPOSCHANGED = 71;

			public const int WM_WINDOWPOSCHANGING = 70;

			public const int WM_WININICHANGE = 26;

			public const int WM_XBUTTONDBLCLK = 525;

			public const int WM_XBUTTONDOWN = 523;

			public const int WM_XBUTTONUP = 524;

			public const int WPF_SETMINPOSITION = 1;

			public const int WS_BORDER = 8388608;

			public const int WS_CAPTION = 12582912;

			public const int WS_CHILD = 1073741824;

			public const int WS_CLIPCHILDREN = 33554432;

			public const int WS_CLIPSIBLINGS = 67108864;

			public const int WS_DISABLED = 134217728;

			public const int WS_DLGFRAME = 4194304;

			public const int WS_EX_APPWINDOW = 262144;

			public const int WS_EX_CLIENTEDGE = 512;

			public const int WS_EX_CONTEXTHELP = 1024;

			public const int WS_EX_CONTROLPARENT = 65536;

			public const int WS_EX_DLGMODALFRAME = 1;

			public const int WS_EX_LAYERED = 524288;

			public const int WS_EX_LAYOUTRTL = 4194304;

			public const int WS_EX_LEFT = 0;

			public const int WS_EX_LEFTSCROLLBAR = 16384;

			public const int WS_EX_MDICHILD = 64;

			public const int WS_EX_NOINHERITLAYOUT = 1048576;

			public const int WS_EX_RIGHT = 4096;

			public const int WS_EX_RTLREADING = 8192;

			public const int WS_EX_STATICEDGE = 131072;

			public const int WS_EX_TOOLWINDOW = 128;

			public const int WS_EX_TOPMOST = 8;

			public const int WS_HSCROLL = 1048576;

			public const int WS_MAXIMIZE = 16777216;

			public const int WS_MAXIMIZEBOX = 65536;

			public const int WS_MINIMIZE = 536870912;

			public const int WS_MINIMIZEBOX = 131072;

			public const int WS_OVERLAPPED = 0;

			public const int WS_POPUP = int.MinValue;

			public const int WS_SYSMENU = 524288;

			public const int WS_TABSTOP = 65536;

			public const int WS_THICKFRAME = 262144;

			public const int WS_VISIBLE = 268435456;

			public const int WS_VSCROLL = 2097152;

			public const int WSF_VISIBLE = 1;

			public const int XBUTTON1 = 1;

			public const int XBUTTON2 = 2;

			public static readonly int ACM_OPEN;

			public static readonly int BFFM_SETSELECTION;

			public static readonly int CBEM_GETITEM;

			public static readonly int CBEM_INSERTITEM;

			public static readonly int CBEM_SETITEM;

			public static readonly int CBEN_ENDEDIT;

			public static readonly int DTM_SETFORMAT;

			public static readonly int DTN_FORMAT;

			public static readonly int DTN_FORMATQUERY;

			public static readonly int DTN_USERSTRING;

			public static readonly int DTN_WMKEYDOWN;

			public static readonly int EMR_POLYTEXTOUT;

			public static readonly int HDM_GETITEM;

			public static readonly int HDM_INSERTITEM;

			public static readonly int HDM_SETITEM;

			public static readonly int HDN_BEGINTRACK;

			public static readonly int HDN_DIVIDERDBLCLICK;

			public static readonly int HDN_ENDTRACK;

			public static readonly int HDN_GETDISPINFO;

			public static readonly int HDN_ITEMCHANGED;

			public static readonly int HDN_ITEMCHANGING;

			public static readonly int HDN_ITEMCLICK;

			public static readonly int HDN_ITEMDBLCLICK;

			public static readonly int HDN_TRACK;

			public static HandleRef HWND_BOTTOM;

			public static HandleRef HWND_MESSAGE;

			public static HandleRef HWND_NOTOPMOST;

			public static HandleRef HWND_TOP;

			public static HandleRef HWND_TOPMOST;

			public static IntPtr InvalidIntPtr;

			public static readonly int LANG_USER_DEFAULT;

			public static readonly int LOCALE_USER_DEFAULT;

			public static IntPtr LPSTR_TEXTCALLBACK;

			public static readonly int LVM_EDITLABEL;

			public static readonly int LVM_FINDITEM;

			public static readonly int LVM_GETCOLUMN;

			public static readonly int LVM_GETISEARCHSTRING;

			public static readonly int LVM_GETITEM;

			public static readonly int LVM_GETITEMTEXT;

			public static readonly int LVM_GETSTRINGWIDTH;

			public static readonly int LVM_INSERTCOLUMN;

			public static readonly int LVM_INSERTITEM;

			public static readonly int LVM_SETBKIMAGE;

			public static readonly int LVM_SETCOLUMN;

			public static readonly int LVM_SETITEM;

			public static readonly int LVM_SETITEMTEXT;

			public static readonly int LVN_BEGINLABELEDIT;

			public static readonly int LVN_ENDLABELEDIT;

			public static readonly int LVN_GETDISPINFO;

			public static readonly int LVN_GETINFOTIP;

			public static readonly int LVN_ODFINDITEM;

			public static readonly int LVN_SETDISPINFO;

			public static HandleRef NullHandleRef;

			public static readonly int PSM_SETFINISHTEXT;

			public static readonly int PSM_SETTITLE;

			public static readonly int RB_INSERTBAND;

			public static readonly int SB_GETTEXT;

			public static readonly int SB_GETTEXTLENGTH;

			public static readonly int SB_GETTIPTEXT;

			public static readonly int SB_SETTEXT;

			public static readonly int SB_SETTIPTEXT;

			public static int START_PAGE_GENERAL;

			public static readonly int TB_ADDBUTTONS;

			public static readonly int TB_ADDSTRING;

			public static readonly int TB_GETBUTTONINFO;

			public static readonly int TB_GETBUTTONTEXT;

			public static readonly int TB_INSERTBUTTON;

			public static readonly int TB_MAPACCELERATOR;

			public static readonly int TB_SAVERESTORE;

			public static readonly int TB_SETBUTTONINFO;

			public static readonly int TBN_GETBUTTONINFO;

			public static readonly int TBN_GETDISPINFO;

			public static readonly int TBN_GETINFOTIP;

			public static readonly int TCM_GETITEM;

			public static readonly int TCM_INSERTITEM;

			public static readonly int TCM_SETITEM;

			public static readonly int TTM_ADDTOOL;

			public static readonly int TTM_DELTOOL;

			public static readonly int TTM_ENUMTOOLS;

			public static readonly int TTM_GETCURRENTTOOL;

			public static readonly int TTM_GETTEXT;

			public static readonly int TTM_GETTOOLINFO;

			public static readonly int TTM_HITTEST;

			public static readonly int TTM_NEWTOOLRECT;

			public static readonly int TTM_SETTITLE;

			public static readonly int TTM_SETTOOLINFO;

			public static readonly int TTM_UPDATETIPTEXT;

			public static readonly int TTN_GETDISPINFO;

			public static readonly int TTN_NEEDTEXT;

			public static readonly int TVM_EDITLABEL;

			public static readonly int TVM_GETISEARCHSTRING;

			public static readonly int TVM_GETITEM;

			public static readonly int TVM_INSERTITEM;

			public static readonly int TVM_SETITEM;

			public static readonly int TVN_BEGINDRAG;

			public static readonly int TVN_BEGINLABELEDIT;

			public static readonly int TVN_BEGINRDRAG;

			public static readonly int TVN_ENDLABELEDIT;

			public static readonly int TVN_GETDISPINFO;

			public static readonly int TVN_ITEMEXPANDED;

			public static readonly int TVN_ITEMEXPANDING;

			public static readonly int TVN_SELCHANGED;

			public static readonly int TVN_SELCHANGING;

			public static readonly int TVN_SETDISPINFO;
		}

		[DllImport("user32")]
		public static extern long DrawIcon(long hdc, long x, long y, long hIcon);

		[DllImport("user32")]
		public static extern long DestroyIcon(long hIcon);

		[DllImport("user32.dll")]
		public static extern IntPtr mouse_event(MouseEventFlags dwflags, int dx, int dy, int dwData, int dwExtraInfo);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, long wParam, long lParam);

		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		public static extern IntPtr SetActiveWindow(HandleRef hWnd);

		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		public static extern bool SetForegroundWindow(HandleRef hWnd);

		[DllImport("user32.dll")]
		public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

		[DllImport("user32.dll")]
		public static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

		[DllImport("user32.dll")]
		public static extern int GetSystemMetrics(int nIndex);

		[DllImport("user32.dll")]
		public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

		[DllImport("user32.dll")]
		public static extern bool GetWindowRect(IntPtr hWnd, ref Rectangle lpRect);

		[DllImport("user32.dll")]
		public static extern bool IsWindow(IntPtr hWnd);

		[DllImport("user32.dll")]
		public static extern bool DeleteMenu(IntPtr hMenu, int uPosition, int uFlags);

		[DllImport("user32.dll")]
		public static extern bool DrawMenuBar(IntPtr hWnd);

		[DllImport("user32.dll")]
		public static extern bool EnableMenuItem(IntPtr hMenu, int uIDEnableItem, int uFlags);

		[DllImport("user32.dll")]
		public static extern bool LockWindowUpdate(IntPtr hWnd);

		[DllImport("user32.dll")]
		public static extern int ReleaseCapture();

		[DllImport("user32.dll")]
		public static extern bool RemoveMenu(IntPtr hMenu, int uPosition, int uFlags);

		[DllImport("user32.dll")]
		public static extern IntPtr SetWindowLong(IntPtr hWnd, int nIndex, IntPtr nNewLong);

		[DllImport("user32.dll")]
		public static extern int SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);

		[DllImport("user32.dll")]
		public static extern bool FlashWindow(IntPtr hwnd, bool bInvert);

		[DllImport("user32.dll")]
		public static extern bool TrackMouseEvent(ref LPTRACKMOUSEEVENT lpEventTrack);

		[DllImport("user32.dll")]
		public static extern bool TrackPopupMenu(IntPtr hMenu, uint uFlags, int x, int y, int nReserved, IntPtr hWnd, IntPtr prcRect);

		[DllImport("shell32", EntryPoint = "ExtractIconEx")]
		public static extern long ExtractIcon(string lpszFile, int niconIndex, ref IntPtr phiconLarge, ref IntPtr phiconSmall, int nIcons);
	}
}
