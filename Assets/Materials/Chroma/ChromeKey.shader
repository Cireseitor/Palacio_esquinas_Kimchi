// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.36 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.36;sub:START;pass:START;ps:flbk:,iptp:0,cusa:True,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:True,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:True,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:1873,x:35436,y:32424,varname:node_1873,prsc:2|emission-1286-OUT,alpha-1659-OUT;n:type:ShaderForge.SFN_Tex2d,id:4805,x:32429,y:32924,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:True,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:5983,x:32423,y:32708,ptovrint:False,ptlb:MaskCol,ptin:_MaskCol,varname:_Color_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:1,c3:0,c4:1;n:type:ShaderForge.SFN_Multiply,id:4654,x:32889,y:31992,varname:node_4654,prsc:2|A-4665-OUT,B-5983-R;n:type:ShaderForge.SFN_Add,id:7442,x:33105,y:32063,varname:node_7442,prsc:2|A-4654-OUT,B-9000-OUT;n:type:ShaderForge.SFN_Vector1,id:4665,x:32421,y:32181,varname:node_4665,prsc:2,v1:0.2989;n:type:ShaderForge.SFN_Multiply,id:9000,x:32889,y:32135,varname:node_9000,prsc:2|A-8136-OUT,B-5983-G;n:type:ShaderForge.SFN_Multiply,id:9101,x:32889,y:32278,varname:node_9101,prsc:2|A-2457-OUT,B-5983-B;n:type:ShaderForge.SFN_Vector1,id:8136,x:32421,y:32240,varname:node_8136,prsc:2,v1:0.5866;n:type:ShaderForge.SFN_Vector1,id:2457,x:32421,y:32300,varname:node_2457,prsc:2,v1:0.1145;n:type:ShaderForge.SFN_Add,id:1158,x:33105,y:32260,cmnt:maskY,varname:node_1158,prsc:2|A-7442-OUT,B-9101-OUT;n:type:ShaderForge.SFN_Vector1,id:5453,x:32421,y:32358,varname:node_5453,prsc:2,v1:0.7132;n:type:ShaderForge.SFN_Subtract,id:2733,x:33575,y:32483,varname:node_2733,prsc:2|A-5983-R,B-1158-OUT;n:type:ShaderForge.SFN_Multiply,id:2310,x:33776,y:32448,cmnt:maskCr,varname:node_2310,prsc:2|A-5453-OUT,B-2733-OUT;n:type:ShaderForge.SFN_Vector1,id:3204,x:32421,y:32419,varname:node_3204,prsc:2,v1:0.5647;n:type:ShaderForge.SFN_Subtract,id:5137,x:33575,y:32660,varname:node_5137,prsc:2|A-5983-B,B-1158-OUT;n:type:ShaderForge.SFN_Multiply,id:8900,x:33775,y:32640,cmnt:maskCb,varname:node_8900,prsc:2|A-3204-OUT,B-5137-OUT;n:type:ShaderForge.SFN_Multiply,id:1789,x:32898,y:32855,varname:node_1789,prsc:2|A-4665-OUT,B-4805-R;n:type:ShaderForge.SFN_Multiply,id:5282,x:32898,y:32991,varname:node_5282,prsc:2|A-8136-OUT,B-4805-G;n:type:ShaderForge.SFN_Multiply,id:4332,x:32898,y:33136,varname:node_4332,prsc:2|A-2457-OUT,B-4805-B;n:type:ShaderForge.SFN_Add,id:3099,x:33116,y:33086,cmnt:Y,varname:node_3099,prsc:2|A-638-OUT,B-4332-OUT;n:type:ShaderForge.SFN_Add,id:638,x:33116,y:32921,varname:node_638,prsc:2|A-1789-OUT,B-5282-OUT;n:type:ShaderForge.SFN_Subtract,id:1458,x:33575,y:32866,varname:node_1458,prsc:2|A-4805-R,B-3099-OUT;n:type:ShaderForge.SFN_Multiply,id:9467,x:33775,y:32866,cmnt:Cr,varname:node_9467,prsc:2|A-1458-OUT,B-5453-OUT;n:type:ShaderForge.SFN_Subtract,id:40,x:33575,y:33056,varname:node_40,prsc:2|A-4805-B,B-3099-OUT;n:type:ShaderForge.SFN_Multiply,id:3183,x:33775,y:33056,cmnt:Cb,varname:node_3183,prsc:2|A-40-OUT,B-3204-OUT;n:type:ShaderForge.SFN_Smoothstep,id:1659,x:34982,y:32507,varname:node_1659,prsc:2|A-1236-OUT,B-295-OUT,V-4101-OUT;n:type:ShaderForge.SFN_Slider,id:1236,x:34314,y:32333,ptovrint:False,ptlb:Sensitivity,ptin:_Sensitivity,varname:node_1236,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:3160,x:34314,y:32433,ptovrint:False,ptlb:Smoothing,ptin:_Smoothing,varname:node_3160,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Add,id:295,x:34695,y:32412,varname:node_295,prsc:2|A-1236-OUT,B-3160-OUT;n:type:ShaderForge.SFN_Distance,id:4101,x:34356,y:32613,varname:node_4101,prsc:2|A-8187-OUT,B-4537-OUT;n:type:ShaderForge.SFN_Append,id:4537,x:34076,y:32763,varname:node_4537,prsc:2|A-9467-OUT,B-3183-OUT;n:type:ShaderForge.SFN_Append,id:8187,x:34076,y:32613,varname:node_8187,prsc:2|A-2310-OUT,B-8900-OUT;n:type:ShaderForge.SFN_Multiply,id:1286,x:35184,y:32728,varname:node_1286,prsc:2|A-4805-RGB,B-1659-OUT;proporder:4805-5983-1236-3160;pass:END;sub:END;*/

Shader "Sprites/ChromaKey" {
    Properties {
        [PerRendererData]_MainTex ("MainTex", 2D) = "white" {}
        _MaskCol ("MaskCol", Color) = (0,1,0,1)
        _Sensitivity ("Sensitivity", Range(0, 1)) = 0
        _Smoothing ("Smoothing", Range(0, 1)) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
            "CanUseSpriteAtlas"="True"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            ZWrite Off
            
            Stencil {
                Ref 128
            }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #pragma multi_compile _ PIXELSNAP_ON
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _MaskCol;
            uniform float _Sensitivity;
            uniform float _Smoothing;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos(v.vertex );
                #ifdef PIXELSNAP_ON
                    o.pos = UnityPixelSnap(o.pos);
                #endif
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
////// Lighting:
////// Emissive:
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float node_5453 = 0.7132;
                float node_4665 = 0.2989;
                float node_8136 = 0.5866;
                float node_2457 = 0.1145;
                float node_1158 = (((node_4665*_MaskCol.r)+(node_8136*_MaskCol.g))+(node_2457*_MaskCol.b)); // maskY
                float node_3204 = 0.5647;
                float node_3099 = (((node_4665*_MainTex_var.r)+(node_8136*_MainTex_var.g))+(node_2457*_MainTex_var.b)); // Y
                float node_1659 = smoothstep( _Sensitivity, (_Sensitivity+_Smoothing), distance(float2((node_5453*(_MaskCol.r-node_1158)),(node_3204*(_MaskCol.b-node_1158))),float2(((_MainTex_var.r-node_3099)*node_5453),((_MainTex_var.b-node_3099)*node_3204))) );
                float3 emissive = (_MainTex_var.rgb*node_1659);
                float3 finalColor = emissive;
                return fixed4(finalColor,node_1659);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #pragma multi_compile _ PIXELSNAP_ON
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal 
            #pragma target 3.0
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos(v.vertex );
                #ifdef PIXELSNAP_ON
                    o.pos = UnityPixelSnap(o.pos);
                #endif
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
