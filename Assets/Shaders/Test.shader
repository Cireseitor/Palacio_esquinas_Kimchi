// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.36 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.36;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33142,y:32651,varname:node_3138,prsc:2|diff-5080-OUT,normal-8241-RGB,emission-1490-OUT,olwid-4376-OUT,olcol-6599-RGB;n:type:ShaderForge.SFN_Tex2d,id:7584,x:30963,y:31910,ptovrint:False,ptlb:Albedo/Diffuse,ptin:_AlbedoDiffuse,varname:node_7584,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:2976,x:31067,y:32738,ptovrint:False,ptlb:Emission Intensity,ptin:_EmissionIntensity,varname:_outline_width_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:10;n:type:ShaderForge.SFN_Multiply,id:9442,x:31629,y:32668,varname:node_9442,prsc:2|A-4476-OUT,B-2976-OUT;n:type:ShaderForge.SFN_LightAttenuation,id:9782,x:30704,y:32776,varname:node_9782,prsc:2;n:type:ShaderForge.SFN_Dot,id:5940,x:29406,y:32994,varname:node_5940,prsc:2,dt:1|A-7742-OUT,B-9651-OUT;n:type:ShaderForge.SFN_NormalVector,id:9651,x:29171,y:33074,prsc:2,pt:True;n:type:ShaderForge.SFN_LightVector,id:7742,x:29160,y:32928,varname:node_7742,prsc:2;n:type:ShaderForge.SFN_Dot,id:6270,x:29406,y:33167,varname:node_6270,prsc:2,dt:1|A-9651-OUT,B-2338-OUT;n:type:ShaderForge.SFN_Add,id:4043,x:30781,y:33368,varname:node_4043,prsc:2|A-5391-OUT,B-809-RGB;n:type:ShaderForge.SFN_Power,id:3157,x:29656,y:33320,cmnt:Specular Light,varname:node_3157,prsc:2|VAL-6270-OUT,EXP-5414-OUT;n:type:ShaderForge.SFN_HalfVector,id:2338,x:29171,y:33225,varname:node_2338,prsc:2;n:type:ShaderForge.SFN_LightColor,id:4821,x:30704,y:32964,varname:node_4821,prsc:2;n:type:ShaderForge.SFN_Multiply,id:6482,x:31011,y:33126,varname:node_6482,prsc:2|A-9782-OUT,B-4821-RGB,C-4043-OUT;n:type:ShaderForge.SFN_Color,id:2964,x:30382,y:32778,ptovrint:False,ptlb:Posterize Light color,ptin:_PosterizeLightcolor,varname:_Color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.6544118,c2:0.8426978,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:5391,x:30541,y:33108,cmnt:Diffuse Light,varname:node_5391,prsc:2|A-4279-OUT,B-2964-RGB,C-9936-OUT;n:type:ShaderForge.SFN_AmbientLight,id:809,x:30387,y:33554,varname:node_809,prsc:2;n:type:ShaderForge.SFN_Slider,id:9417,x:28928,y:33431,ptovrint:False,ptlb:Posterize Gloss,ptin:_PosterizeGloss,varname:_Gloss,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.2,cur:0.2,max:0.2;n:type:ShaderForge.SFN_Add,id:9827,x:29559,y:33628,varname:node_9827,prsc:2|A-3159-OUT,B-3260-OUT;n:type:ShaderForge.SFN_Vector1,id:3260,x:29391,y:33716,varname:node_3260,prsc:2,v1:4;n:type:ShaderForge.SFN_Multiply,id:3159,x:29353,y:33520,varname:node_3159,prsc:2|A-5026-OUT,B-4884-OUT;n:type:ShaderForge.SFN_Vector1,id:4884,x:28986,y:33732,varname:node_4884,prsc:2,v1:8;n:type:ShaderForge.SFN_Exp,id:5414,x:29731,y:33628,varname:node_5414,prsc:2,et:1|IN-9827-OUT;n:type:ShaderForge.SFN_Posterize,id:6981,x:29820,y:32929,varname:node_6981,prsc:2|IN-5940-OUT,STPS-2693-OUT;n:type:ShaderForge.SFN_Posterize,id:2601,x:29895,y:33320,varname:node_2601,prsc:2|IN-3157-OUT,STPS-7188-OUT;n:type:ShaderForge.SFN_Add,id:9936,x:30103,y:33214,varname:node_9936,prsc:2|A-99-OUT,B-2601-OUT;n:type:ShaderForge.SFN_Vector3,id:4279,x:30353,y:33025,varname:node_4279,prsc:2,v1:1,v2:1,v3:1;n:type:ShaderForge.SFN_Tex2d,id:8241,x:32528,y:32953,ptovrint:False,ptlb:Normal Map,ptin:_NormalMap,varname:_Albedo_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Slider,id:2693,x:29594,y:33169,ptovrint:False,ptlb:Posterize Bands,ptin:_PosterizeBands,varname:_PosterizeGloss_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:50,cur:50,max:50;n:type:ShaderForge.SFN_SwitchProperty,id:8426,x:32016,y:32977,ptovrint:False,ptlb:Enable Posterize,ptin:_EnablePosterize,varname:node_8426,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-9442-OUT,B-4364-OUT;n:type:ShaderForge.SFN_Multiply,id:4364,x:31269,y:33126,varname:node_4364,prsc:2|A-9442-OUT,B-6482-OUT;n:type:ShaderForge.SFN_Color,id:6497,x:30993,y:32330,ptovrint:False,ptlb:Diffuse_Color,ptin:_Diffuse_Color,varname:_PosterizeLightcolor_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.6509804,c2:0.8392158,c3:1,c4:1;n:type:ShaderForge.SFN_SwitchProperty,id:4476,x:31420,y:32474,ptovrint:False,ptlb:Enable_Diffuse_Texture,ptin:_Enable_Diffuse_Texture,varname:_EnablePosterize_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-6497-RGB,B-7584-RGB;n:type:ShaderForge.SFN_Slider,id:6758,x:31969,y:33179,ptovrint:False,ptlb:Outline Width,ptin:_OutlineWidth,varname:node_6758,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:0;n:type:ShaderForge.SFN_Color,id:6599,x:32349,y:33338,ptovrint:False,ptlb:Color_Outline,ptin:_Color_Outline,varname:node_6599,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Vector1,id:7224,x:32126,y:33264,varname:node_7224,prsc:2,v1:10000;n:type:ShaderForge.SFN_Divide,id:4376,x:32416,y:33123,varname:node_4376,prsc:2|A-6758-OUT,B-7224-OUT;n:type:ShaderForge.SFN_Multiply,id:956,x:32199,y:31846,varname:node_956,prsc:2|A-7584-RGB,B-5188-OUT;n:type:ShaderForge.SFN_AmbientLight,id:6295,x:31621,y:31981,varname:node_6295,prsc:2;n:type:ShaderForge.SFN_SwitchProperty,id:2815,x:32667,y:31920,ptovrint:False,ptlb:Ambien_Light,ptin:_Ambien_Light,varname:node_2815,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True|A-2854-OUT,B-956-OUT;n:type:ShaderForge.SFN_Vector1,id:2854,x:32157,y:31720,varname:node_2854,prsc:2,v1:0.1;n:type:ShaderForge.SFN_TexCoord,id:7809,x:29298,y:32656,varname:node_7809,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_ComponentMask,id:8457,x:29499,y:32670,varname:node_8457,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-7809-UVOUT;n:type:ShaderForge.SFN_Add,id:99,x:30026,y:32890,varname:node_99,prsc:2|A-6981-OUT,B-6321-OUT;n:type:ShaderForge.SFN_Vector1,id:6321,x:29942,y:33043,varname:node_6321,prsc:2,v1:0;n:type:ShaderForge.SFN_Multiply,id:5868,x:31823,y:32141,varname:node_5868,prsc:2|A-6295-RGB,B-9716-OUT;n:type:ShaderForge.SFN_Slider,id:1331,x:31426,y:32264,ptovrint:False,ptlb:Intensity_Ambient_light,ptin:_Intensity_Ambient_light,varname:node_1331,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2,max:1;n:type:ShaderForge.SFN_NormalVector,id:1665,x:31446,y:33832,prsc:2,pt:False;n:type:ShaderForge.SFN_LightVector,id:2557,x:31538,y:34093,varname:node_2557,prsc:2;n:type:ShaderForge.SFN_Dot,id:8634,x:31892,y:33894,varname:node_8634,prsc:2,dt:0|A-1665-OUT,B-2557-OUT;n:type:ShaderForge.SFN_Multiply,id:8988,x:32007,y:33591,varname:node_8988,prsc:2|A-8634-OUT,B-5336-OUT;n:type:ShaderForge.SFN_LightAttenuation,id:5336,x:31529,y:33575,varname:node_5336,prsc:2;n:type:ShaderForge.SFN_Tex2d,id:9405,x:32487,y:33580,ptovrint:False,ptlb:Ramp_1,ptin:_Ramp_1,varname:node_9405,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:f950c614a628e0f48892da4b92ccf4a8,ntxv:0,isnm:False|UVIN-3570-OUT;n:type:ShaderForge.SFN_Multiply,id:5525,x:32073,y:32187,varname:node_5525,prsc:2|A-8031-RGB,B-5868-OUT;n:type:ShaderForge.SFN_LightColor,id:8031,x:31866,y:32390,varname:node_8031,prsc:2;n:type:ShaderForge.SFN_LightVector,id:5439,x:32073,y:32579,varname:node_5439,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:8046,x:32055,y:32464,prsc:2,pt:False;n:type:ShaderForge.SFN_Dot,id:2614,x:32250,y:32423,varname:node_2614,prsc:2,dt:1|A-8046-OUT,B-5439-OUT;n:type:ShaderForge.SFN_Multiply,id:5188,x:32386,y:32155,varname:node_5188,prsc:2|A-5525-OUT,B-2614-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:5080,x:32935,y:32283,ptovrint:False,ptlb:Enable_Ramp,ptin:_Enable_Ramp,varname:node_5080,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-2815-OUT,B-9065-OUT;n:type:ShaderForge.SFN_Append,id:3570,x:32200,y:33863,varname:node_3570,prsc:2|A-8634-OUT,B-8634-OUT;n:type:ShaderForge.SFN_ObjectPosition,id:7785,x:31699,y:33699,varname:node_7785,prsc:2;n:type:ShaderForge.SFN_Cubemap,id:6044,x:32517,y:32586,ptovrint:False,ptlb:cube_Map,ptin:_cube_Map,varname:node_6044,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,cube:b995d4bd9d11078d11005b9844295342,pvfc:0|DIR-3947-XYZ;n:type:ShaderForge.SFN_Multiply,id:3446,x:32269,y:32977,varname:node_3446,prsc:2|A-5949-RGB,B-8426-OUT;n:type:ShaderForge.SFN_Color,id:5949,x:32095,y:32805,ptovrint:False,ptlb:Main_Color,ptin:_Main_Color,varname:node_5949,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:1490,x:32856,y:32630,varname:node_1490,prsc:2|A-6044-RGB,B-3446-OUT;n:type:ShaderForge.SFN_NormalVector,id:5730,x:32271,y:32721,prsc:2,pt:False;n:type:ShaderForge.SFN_Transform,id:3947,x:32422,y:32721,varname:node_3947,prsc:2,tffrom:0,tfto:3|IN-5730-OUT;n:type:ShaderForge.SFN_Multiply,id:9065,x:32651,y:32320,varname:node_9065,prsc:2|A-2815-OUT,B-1562-OUT;n:type:ShaderForge.SFN_Power,id:1562,x:32823,y:33444,varname:node_1562,prsc:2|VAL-9405-RGB,EXP-6714-OUT;n:type:ShaderForge.SFN_Slider,id:6714,x:32623,y:33762,ptovrint:False,ptlb:Power_Ramp,ptin:_Power_Ramp,varname:node_6714,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-20,cur:1,max:20;n:type:ShaderForge.SFN_Vector1,id:7803,x:31293,y:32627,varname:node_7803,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:7423,x:32687,y:33631,varname:node_7423,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Vector1,id:7188,x:29829,y:33207,varname:node_7188,prsc:2,v1:50;n:type:ShaderForge.SFN_Vector1,id:5026,x:28983,y:33267,varname:node_5026,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Vector1,id:9716,x:31583,y:32155,varname:node_9716,prsc:2,v1:0.2;proporder:4476-6497-7584-2976-8241-8426-2693-9417-2964-6758-6599-2815-1331-5080-9405-6044-5949-6714;pass:END;sub:END;*/

Shader "Shader Forge/Test" {
    Properties {
        [MaterialToggle] _Enable_Diffuse_Texture ("Enable_Diffuse_Texture", Float ) = 0.6509804
        _Diffuse_Color ("Diffuse_Color", Color) = (0.6509804,0.8392158,1,1)
        _AlbedoDiffuse ("Albedo/Diffuse", 2D) = "white" {}
        _EmissionIntensity ("Emission Intensity", Range(0, 10)) = 1
        _NormalMap ("Normal Map", 2D) = "bump" {}
        [MaterialToggle] _EnablePosterize ("Enable Posterize", Float ) = 0.6509804
        _PosterizeBands ("Posterize Bands", Range(50, 50)) = 50
        _PosterizeGloss ("Posterize Gloss", Range(0.2, 0.2)) = 0.2
        _PosterizeLightcolor ("Posterize Light color", Color) = (0.6544118,0.8426978,1,1)
        _OutlineWidth ("Outline Width", Range(0, 0)) = 0
        _Color_Outline ("Color_Outline", Color) = (0,0,0,1)
        [MaterialToggle] _Ambien_Light ("Ambien_Light", Float ) = 0
        _Intensity_Ambient_light ("Intensity_Ambient_light", Range(0, 1)) = 0.2
        [MaterialToggle] _Enable_Ramp ("Enable_Ramp", Float ) = 0
        _Ramp_1 ("Ramp_1", 2D) = "white" {}
        _cube_Map ("cube_Map", Cube) = "_Skybox" {}
        _Main_Color ("Main_Color", Color) = (0.5,0.5,0.5,1)
        _Power_Ramp ("Power_Ramp", Range(-20, 20)) = 1
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "Outline"
            Tags {
            }
            Cull Front
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal n3ds wiiu 
            #pragma target 3.0
            uniform float _OutlineWidth;
            uniform float4 _Color_Outline;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos(float4(v.vertex.xyz + v.normal*(_OutlineWidth/10000.0),1) );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                return fixed4(_Color_Outline.rgb,0);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal n3ds wiiu 
            #pragma target 3.0
            uniform sampler2D _AlbedoDiffuse; uniform float4 _AlbedoDiffuse_ST;
            uniform float _EmissionIntensity;
            uniform float4 _PosterizeLightcolor;
            uniform sampler2D _NormalMap; uniform float4 _NormalMap_ST;
            uniform float _PosterizeBands;
            uniform fixed _EnablePosterize;
            uniform float4 _Diffuse_Color;
            uniform fixed _Enable_Diffuse_Texture;
            uniform fixed _Ambien_Light;
            uniform sampler2D _Ramp_1; uniform float4 _Ramp_1_ST;
            uniform fixed _Enable_Ramp;
            uniform samplerCUBE _cube_Map;
            uniform float4 _Main_Color;
            uniform float _Power_Ramp;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _NormalMap_var = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(i.uv0, _NormalMap)));
                float3 normalLocal = _NormalMap_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 _AlbedoDiffuse_var = tex2D(_AlbedoDiffuse,TRANSFORM_TEX(i.uv0, _AlbedoDiffuse));
                float3 _Ambien_Light_var = lerp( 0.1, (_AlbedoDiffuse_var.rgb*((_LightColor0.rgb*(UNITY_LIGHTMODEL_AMBIENT.rgb*0.2))*max(0,dot(i.normalDir,lightDirection)))), _Ambien_Light );
                float node_8634 = dot(i.normalDir,lightDirection);
                float2 node_3570 = float2(node_8634,node_8634);
                float4 _Ramp_1_var = tex2D(_Ramp_1,TRANSFORM_TEX(node_3570, _Ramp_1));
                float3 diffuseColor = lerp( _Ambien_Light_var, (_Ambien_Light_var*pow(_Ramp_1_var.rgb,_Power_Ramp)), _Enable_Ramp );
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float3 node_9442 = (lerp( _Diffuse_Color.rgb, _AlbedoDiffuse_var.rgb, _Enable_Diffuse_Texture )*_EmissionIntensity);
                float node_7188 = 50.0;
                float3 emissive = (texCUBE(_cube_Map,mul( UNITY_MATRIX_V, float4(i.normalDir,0) ).xyz.rgb).rgb*(_Main_Color.rgb*lerp( node_9442, (node_9442*(attenuation*_LightColor0.rgb*((float3(1,1,1)*_PosterizeLightcolor.rgb*((floor(max(0,dot(lightDirection,normalDirection)) * _PosterizeBands) / (_PosterizeBands - 1)+0.0)+floor(pow(max(0,dot(normalDirection,halfDirection)),exp2(((0.2*8.0)+4.0))) * node_7188) / (node_7188 - 1)))+UNITY_LIGHTMODEL_AMBIENT.rgb))), _EnablePosterize )));
/// Final Color:
                float3 finalColor = diffuse + emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal n3ds wiiu 
            #pragma target 3.0
            uniform sampler2D _AlbedoDiffuse; uniform float4 _AlbedoDiffuse_ST;
            uniform float _EmissionIntensity;
            uniform float4 _PosterizeLightcolor;
            uniform sampler2D _NormalMap; uniform float4 _NormalMap_ST;
            uniform float _PosterizeBands;
            uniform fixed _EnablePosterize;
            uniform float4 _Diffuse_Color;
            uniform fixed _Enable_Diffuse_Texture;
            uniform fixed _Ambien_Light;
            uniform sampler2D _Ramp_1; uniform float4 _Ramp_1_ST;
            uniform fixed _Enable_Ramp;
            uniform samplerCUBE _cube_Map;
            uniform float4 _Main_Color;
            uniform float _Power_Ramp;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _NormalMap_var = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(i.uv0, _NormalMap)));
                float3 normalLocal = _NormalMap_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _AlbedoDiffuse_var = tex2D(_AlbedoDiffuse,TRANSFORM_TEX(i.uv0, _AlbedoDiffuse));
                float3 _Ambien_Light_var = lerp( 0.1, (_AlbedoDiffuse_var.rgb*((_LightColor0.rgb*(UNITY_LIGHTMODEL_AMBIENT.rgb*0.2))*max(0,dot(i.normalDir,lightDirection)))), _Ambien_Light );
                float node_8634 = dot(i.normalDir,lightDirection);
                float2 node_3570 = float2(node_8634,node_8634);
                float4 _Ramp_1_var = tex2D(_Ramp_1,TRANSFORM_TEX(node_3570, _Ramp_1));
                float3 diffuseColor = lerp( _Ambien_Light_var, (_Ambien_Light_var*pow(_Ramp_1_var.rgb,_Power_Ramp)), _Enable_Ramp );
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
