// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.36 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.36;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:32719,y:32712,varname:node_2865,prsc:2|emission-2045-OUT,alpha-2691-OUT;n:type:ShaderForge.SFN_Fresnel,id:2691,x:31887,y:32898,varname:node_2691,prsc:2|EXP-7740-OUT;n:type:ShaderForge.SFN_Slider,id:7740,x:31377,y:32910,ptovrint:False,ptlb:Fresnel_Intensidad_Interior,ptin:_Fresnel_Intensidad_Interior,varname:node_7740,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.9859526,max:10;n:type:ShaderForge.SFN_Multiply,id:5923,x:32137,y:32615,varname:node_5923,prsc:2|A-7456-RGB,B-2691-OUT;n:type:ShaderForge.SFN_Color,id:7456,x:31828,y:32539,ptovrint:False,ptlb:Color_Fresnel_Interior,ptin:_Color_Fresnel_Interior,varname:node_7456,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.02745098,c3:0.3686275,c4:1;n:type:ShaderForge.SFN_ComponentMask,id:8852,x:31229,y:33344,varname:node_8852,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-8249-OUT;n:type:ShaderForge.SFN_ArcTan,id:8249,x:31016,y:33354,varname:node_8249,prsc:2|IN-2236-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:2236,x:30831,y:33356,varname:node_2236,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_ArcCos,id:7553,x:31042,y:33180,varname:node_7553,prsc:2|IN-2236-UVOUT;n:type:ShaderForge.SFN_ComponentMask,id:6436,x:31246,y:33180,varname:node_6436,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-7553-OUT;n:type:ShaderForge.SFN_TexCoord,id:8897,x:31286,y:33613,varname:node_8897,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_RemapRange,id:9363,x:31576,y:33592,varname:node_9363,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-8897-UVOUT;n:type:ShaderForge.SFN_Length,id:5483,x:31812,y:33610,varname:node_5483,prsc:2|IN-9363-OUT;n:type:ShaderForge.SFN_Add,id:6012,x:32020,y:33576,varname:node_6012,prsc:2|A-6314-OUT,B-5483-OUT;n:type:ShaderForge.SFN_Floor,id:2375,x:32183,y:33513,varname:node_2375,prsc:2|IN-6012-OUT;n:type:ShaderForge.SFN_Vector1,id:6314,x:31862,y:33533,varname:node_6314,prsc:2,v1:0.6;n:type:ShaderForge.SFN_OneMinus,id:7346,x:32183,y:33362,varname:node_7346,prsc:2|IN-2375-OUT;n:type:ShaderForge.SFN_Multiply,id:6836,x:31741,y:31651,varname:node_6836,prsc:2|A-1789-UVOUT,B-7491-OUT;n:type:ShaderForge.SFN_Tex2d,id:1847,x:31966,y:31781,varname:node_1847,prsc:2,ntxv:0,isnm:False|UVIN-6836-OUT,TEX-6633-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:6633,x:31654,y:31756,ptovrint:False,ptlb:Textura_Malla,ptin:_Textura_Malla,varname:node_6633,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_TexCoord,id:1789,x:31510,y:31620,varname:node_1789,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Slider,id:7491,x:31181,y:31657,ptovrint:False,ptlb:Textura_Tileada,ptin:_Textura_Tileada,varname:node_7491,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:6.305271,max:100;n:type:ShaderForge.SFN_Add,id:651,x:32374,y:32526,varname:node_651,prsc:2|A-15-OUT,B-5923-OUT;n:type:ShaderForge.SFN_Multiply,id:8769,x:32487,y:31915,varname:node_8769,prsc:2|A-4536-RGB,B-1847-RGB;n:type:ShaderForge.SFN_Color,id:4536,x:32267,y:31696,ptovrint:False,ptlb:Textura_Color,ptin:_Textura_Color,varname:node_4536,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Multiply,id:15,x:32554,y:32117,varname:node_15,prsc:2|A-8769-OUT,B-5381-OUT;n:type:ShaderForge.SFN_Slider,id:5381,x:32085,y:32129,ptovrint:False,ptlb:Fresnel_Intensidad_Textura,ptin:_Fresnel_Intensidad_Textura,varname:node_5381,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:4.402706,max:10;n:type:ShaderForge.SFN_Fresnel,id:137,x:31333,y:32419,varname:node_137,prsc:2|EXP-3992-OUT;n:type:ShaderForge.SFN_Slider,id:3992,x:30977,y:32392,ptovrint:False,ptlb:Fresnel_Intensidad_Exterior,ptin:_Fresnel_Intensidad_Exterior,varname:_Fresnel_Intensidad_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2.306384,max:10;n:type:ShaderForge.SFN_Add,id:2045,x:32597,y:32414,varname:node_2045,prsc:2|A-4072-OUT,B-651-OUT;n:type:ShaderForge.SFN_Multiply,id:8518,x:31644,y:32439,varname:node_8518,prsc:2|A-137-OUT,B-5961-OUT;n:type:ShaderForge.SFN_Vector1,id:5961,x:31288,y:32298,varname:node_5961,prsc:2,v1:10;n:type:ShaderForge.SFN_Multiply,id:4072,x:32096,y:32332,varname:node_4072,prsc:2|A-4702-RGB,B-8518-OUT;n:type:ShaderForge.SFN_Color,id:4702,x:31644,y:32288,ptovrint:False,ptlb:Fresnel_Color_Exterior,ptin:_Fresnel_Color_Exterior,varname:node_4702,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.02157225,c2:0.02816785,c3:0.9779412,c4:1;n:type:ShaderForge.SFN_TexCoord,id:2074,x:31187,y:31952,varname:node_2074,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:3069,x:31739,y:32003,varname:node_3069,prsc:2,spu:0.1,spv:0.1|UVIN-2074-UVOUT,DIST-5881-OUT;n:type:ShaderForge.SFN_Time,id:3715,x:31344,y:32068,varname:node_3715,prsc:2;n:type:ShaderForge.SFN_Rotator,id:8076,x:31810,y:32136,varname:node_8076,prsc:2;n:type:ShaderForge.SFN_Divide,id:5881,x:31540,y:32144,varname:node_5881,prsc:2|A-3715-T,B-7695-OUT;n:type:ShaderForge.SFN_Vector1,id:7695,x:31433,y:32233,varname:node_7695,prsc:2,v1:100;proporder:7456-7740-4536-6633-7491-5381-4702-3992;pass:END;sub:END;*/

Shader "Shader Forge/Pruebas 3" {
    Properties {
        _Color_Fresnel_Interior ("Color_Fresnel_Interior", Color) = (1,0.02745098,0.3686275,1)
        _Fresnel_Intensidad_Interior ("Fresnel_Intensidad_Interior", Range(0, 10)) = 0.9859526
        _Textura_Color ("Textura_Color", Color) = (1,0,0,1)
        _Textura_Malla ("Textura_Malla", 2D) = "white" {}
        _Textura_Tileada ("Textura_Tileada", Range(0, 100)) = 6.305271
        _Fresnel_Intensidad_Textura ("Fresnel_Intensidad_Textura", Range(0, 10)) = 4.402706
        _Fresnel_Color_Exterior ("Fresnel_Color_Exterior", Color) = (0.02157225,0.02816785,0.9779412,1)
        _Fresnel_Intensidad_Exterior ("Fresnel_Intensidad_Exterior", Range(0, 10)) = 2.306384
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles n3ds wiiu 
            #pragma target 3.0
            uniform float _Fresnel_Intensidad_Interior;
            uniform float4 _Color_Fresnel_Interior;
            uniform sampler2D _Textura_Malla; uniform float4 _Textura_Malla_ST;
            uniform float _Textura_Tileada;
            uniform float4 _Textura_Color;
            uniform float _Fresnel_Intensidad_Textura;
            uniform float _Fresnel_Intensidad_Exterior;
            uniform float4 _Fresnel_Color_Exterior;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
////// Lighting:
////// Emissive:
                float2 node_6836 = (i.uv0*_Textura_Tileada);
                float4 node_1847 = tex2D(_Textura_Malla,TRANSFORM_TEX(node_6836, _Textura_Malla));
                float node_2691 = pow(1.0-max(0,dot(normalDirection, viewDirection)),_Fresnel_Intensidad_Interior);
                float3 emissive = ((_Fresnel_Color_Exterior.rgb*(pow(1.0-max(0,dot(normalDirection, viewDirection)),_Fresnel_Intensidad_Exterior)*10.0))+(((_Textura_Color.rgb*node_1847.rgb)*_Fresnel_Intensidad_Textura)+(_Color_Fresnel_Interior.rgb*node_2691)));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,node_2691);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles n3ds wiiu 
            #pragma target 3.0
            uniform float _Fresnel_Intensidad_Interior;
            uniform float4 _Color_Fresnel_Interior;
            uniform sampler2D _Textura_Malla; uniform float4 _Textura_Malla_ST;
            uniform float _Textura_Tileada;
            uniform float4 _Textura_Color;
            uniform float _Fresnel_Intensidad_Textura;
            uniform float _Fresnel_Intensidad_Exterior;
            uniform float4 _Fresnel_Color_Exterior;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float2 node_6836 = (i.uv0*_Textura_Tileada);
                float4 node_1847 = tex2D(_Textura_Malla,TRANSFORM_TEX(node_6836, _Textura_Malla));
                float node_2691 = pow(1.0-max(0,dot(normalDirection, viewDirection)),_Fresnel_Intensidad_Interior);
                o.Emission = ((_Fresnel_Color_Exterior.rgb*(pow(1.0-max(0,dot(normalDirection, viewDirection)),_Fresnel_Intensidad_Exterior)*10.0))+(((_Textura_Color.rgb*node_1847.rgb)*_Fresnel_Intensidad_Textura)+(_Color_Fresnel_Interior.rgb*node_2691)));
                
                float3 diffColor = float3(0,0,0);
                o.Albedo = diffColor;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
