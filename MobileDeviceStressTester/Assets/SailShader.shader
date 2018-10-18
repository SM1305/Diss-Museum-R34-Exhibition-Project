﻿Shader "Tesselate Shader" 
{
	Properties
	{
		_Tess("Tessellation", Range(1,128)) = 4
		_MainTex("Base (RGB)", 2D) = "white" {}
		_DispTex("Disp Texture", 2D) = "gray" {}
		_NormalMap("Normalmap", 2D) = "bump" {}
		_Displacement("Displacement", Range(0, 1.0)) = 0.3
		_Color("Color", color) = (1,1,1,0)
		_SpecColor("Spec color", color) = (0.5,0.5,0.5,0.5)

		_Offset("Displacement Offset", float) = 1
	}
		SubShader{
		Tags{ "RenderType" = "Opaque" }

		LOD 300

		Cull Off
		
		CGPROGRAM

		#pragma surface surf BlinnPhong addshadow fullforwardshadows vertex:disp tessellate:tessDistance nolightmap 
		#pragma target 4.6
		#include "Tessellation.cginc"

		struct appdata {
		float4 vertex : POSITION;
		float4 tangent : TANGENT;
		float3 normal : NORMAL;
		float2 texcoord : TEXCOORD0;
		};

		float _Tess;

	

		float4 tessDistance(appdata v0, appdata v1, appdata v2) {
		float minDist = 100.0;
		float maxDist = 101.0;
		return UnityDistanceBasedTess(v0.vertex, v1.vertex, v2.vertex, minDist, maxDist, _Tess);
		}

		sampler2D _DispTex;
		float _Displacement;
		float _Offset;

		void disp(inout appdata v)
		{
			float vUVY = v.texcoord.y;
			v.texcoord.y += _Offset;
			float d = tex2Dlod(_DispTex, float4(v.texcoord.xy,0,0)).r * _Displacement;
			v.vertex.xyz += v.normal * d;

			v.texcoord.y = vUVY;
		}

		struct Input {
			float2 uv_MainTex;
		};

		sampler2D _MainTex;
		sampler2D _NormalMap;
		fixed4 _Color;

		void surf(Input IN, inout SurfaceOutput o) 
		{
			half4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Specular = 0.2;
			o.Gloss = 0.0;
			o.Normal = UnpackNormal(tex2D(_NormalMap, IN.uv_MainTex));
		}
		ENDCG
		}
	FallBack "Diffuse"
}