// Upgrade NOTE: upgraded instancing buffer 'DiabloPS_Smoke' to new syntax.

// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "PS_Smoke"
{
	Properties
	{
		_LightMap("LightMap", 2D) = "white" {}
		_Mask("Mask", 2D) = "white" {}
		_Tiling3("Tiling3", Vector) = (1,1,0,0)
		_Tiling1("Tiling1", Vector) = (1,1,0,0)
		_Tiling2("Tiling2", Vector) = (1,1,0,0)
		_Mult1("Mult1", Float) = 2
		_Mult2("Mult2", Float) = 2
		_Noise("Noise", 2D) = "white" {}
		[HideInInspector] _tex3coord2( "", 2D ) = "white" {}
		[HideInInspector] _tex3coord3( "", 2D ) = "white" {}
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" }
		Cull Back
		CGINCLUDE
		#include "UnityShaderVariables.cginc"
		#include "UnityPBSLighting.cginc"
		#include "Lighting.cginc"
		#pragma target 3.5
		#pragma multi_compile_instancing
		#undef TRANSFORM_TEX
		#define TRANSFORM_TEX(tex,name) float4(tex.xy * name##_ST.xy + name##_ST.zw, tex.z, tex.w)
		struct Input
		{
			float4 vertexColor : COLOR;
			float2 uv_texcoord;
			float3 uv2_tex3coord2;
			float3 uv3_tex3coord3;
		};

		uniform sampler2D _LightMap;
		uniform float4 _LightMap_ST;
		uniform sampler2D _Noise;
		uniform float2 _Tiling2;
		uniform float _Mult1;
		uniform float2 _Tiling3;
		uniform float _Mult2;
		uniform sampler2D _Mask;
		uniform float4 _Mask_ST;

		UNITY_INSTANCING_BUFFER_START(DiabloPS_Smoke)
			UNITY_DEFINE_INSTANCED_PROP(float2, _Tiling1)
#define _Tiling1_arr DiabloPS_Smoke
		UNITY_INSTANCING_BUFFER_END(DiabloPS_Smoke)

		void surf( Input i , inout SurfaceOutput o )
		{
			float2 uv_LightMap = i.uv_texcoord * _LightMap_ST.xy + _LightMap_ST.zw;
			o.Albedo = ( i.vertexColor * tex2D( _LightMap, uv_LightMap ) ).rgb;
			float temp_output_15_0_g9 = _Time.y;
			float2 temp_cast_1 = (i.uv2_tex3coord2.x).xx;
			float2 _Tiling1_Instance = UNITY_ACCESS_INSTANCED_PROP(_Tiling1_arr, _Tiling1);
			float2 temp_cast_2 = (i.uv3_tex3coord3.x).xx;
			float2 uv_TexCoord154 = i.uv_texcoord * _Tiling1_Instance + temp_cast_2;
			float2 panner21_g11 = ( temp_output_15_0_g9 * temp_cast_1 + uv_TexCoord154);
			float2 temp_cast_3 = (i.uv2_tex3coord2.y).xx;
			float2 temp_cast_4 = (i.uv3_tex3coord3.y).xx;
			float2 uv_TexCoord155 = i.uv_texcoord * _Tiling2 + temp_cast_4;
			float2 panner21_g10 = ( temp_output_15_0_g9 * temp_cast_3 + uv_TexCoord155);
			float2 temp_cast_5 = (i.uv2_tex3coord2.z).xx;
			float2 temp_cast_6 = (i.uv3_tex3coord3.z).xx;
			float2 uv_TexCoord156 = i.uv_texcoord * _Tiling3 + temp_cast_6;
			float2 panner21_g12 = ( temp_output_15_0_g9 * temp_cast_5 + uv_TexCoord156);
			float2 uv_Mask = i.uv_texcoord * _Mask_ST.xy + _Mask_ST.zw;
			float4 opacity94 = ( i.vertexColor.a * ( ( ( ( ( tex2D( _Noise, panner21_g11 ) * tex2D( _Noise, panner21_g10 ) ) * _Mult1 ) * tex2D( _Noise, panner21_g12 ) ) * _Mult2 ) * tex2D( _Mask, uv_Mask ).a ) );
			o.Alpha = opacity94.r;
		}

		ENDCG
		CGPROGRAM
		#pragma surface surf Lambert alpha:fade keepalpha fullforwardshadows 

		ENDCG
		Pass
		{
			Name "ShadowCaster"
			Tags{ "LightMode" = "ShadowCaster" }
			ZWrite On
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 3.5
			#pragma multi_compile_shadowcaster
			#pragma multi_compile UNITY_PASS_SHADOWCASTER
			#pragma skip_variants FOG_LINEAR FOG_EXP FOG_EXP2
			#include "HLSLSupport.cginc"
			#if ( SHADER_API_D3D11 || SHADER_API_GLCORE || SHADER_API_GLES3 || SHADER_API_METAL || SHADER_API_VULKAN )
				#define CAN_SKIP_VPOS
			#endif
			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "UnityPBSLighting.cginc"
			sampler3D _DitherMaskLOD;
			struct v2f
			{
				V2F_SHADOW_CASTER;
				float2 customPack1 : TEXCOORD1;
				float3 customPack2 : TEXCOORD2;
				float3 customPack3 : TEXCOORD3;
				float3 worldPos : TEXCOORD4;
				fixed4 color : COLOR0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};
			v2f vert( appdata_full v )
			{
				v2f o;
				UNITY_SETUP_INSTANCE_ID( v );
				UNITY_INITIALIZE_OUTPUT( v2f, o );
				UNITY_TRANSFER_INSTANCE_ID( v, o );
				Input customInputData;
				float3 worldPos = mul( unity_ObjectToWorld, v.vertex ).xyz;
				fixed3 worldNormal = UnityObjectToWorldNormal( v.normal );
				o.customPack1.xy = customInputData.uv_texcoord;
				o.customPack1.xy = v.texcoord;
				o.customPack2.xyz = customInputData.uv2_tex3coord2;
				o.customPack2.xyz = v.texcoord1;
				o.customPack3.xyz = customInputData.uv3_tex3coord3;
				o.customPack3.xyz = v.texcoord2;
				o.worldPos = worldPos;
				TRANSFER_SHADOW_CASTER_NORMALOFFSET( o )
				o.color = v.color;
				return o;
			}
			fixed4 frag( v2f IN
			#if !defined( CAN_SKIP_VPOS )
			, UNITY_VPOS_TYPE vpos : VPOS
			#endif
			) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID( IN );
				Input surfIN;
				UNITY_INITIALIZE_OUTPUT( Input, surfIN );
				surfIN.uv_texcoord = IN.customPack1.xy;
				surfIN.uv2_tex3coord2 = IN.customPack2.xyz;
				surfIN.uv3_tex3coord3 = IN.customPack3.xyz;
				float3 worldPos = IN.worldPos;
				fixed3 worldViewDir = normalize( UnityWorldSpaceViewDir( worldPos ) );
				surfIN.vertexColor = IN.color;
				SurfaceOutput o;
				UNITY_INITIALIZE_OUTPUT( SurfaceOutput, o )
				surf( surfIN, o );
				#if defined( CAN_SKIP_VPOS )
				float2 vpos = IN.pos;
				#endif
				half alphaRef = tex3D( _DitherMaskLOD, float3( vpos.xy * 0.25, o.Alpha * 0.9375 ) ).a;
				clip( alphaRef - 0.01 );
				SHADOW_CASTER_FRAGMENT( IN )
			}
			ENDCG
		}
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=15301
280;92;973;432;2248.388;386.1294;4.07483;True;False
Node;AmplifyShaderEditor.CommentaryNode;143;-2193.515,143.8762;Float;False;1193.564;1167.511;Comment;10;149;90;154;155;156;81;84;150;78;153;Standard;1,1,1,1;0;0
Node;AmplifyShaderEditor.Vector2Node;78;-2019.308,485.3589;Float;False;InstancedProperty;_Tiling1;Tiling1;3;0;Create;True;0;0;False;0;1,1;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.Vector2Node;81;-2021.148,598.153;Float;False;Property;_Tiling2;Tiling2;4;0;Create;True;0;0;False;0;1,1;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.Vector2Node;84;-2017.568,712.2838;Float;False;Property;_Tiling3;Tiling3;2;0;Create;True;0;0;False;0;1,1;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.TexCoordVertexDataNode;150;-2059.292,825.6033;Float;False;2;3;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TextureCoordinatesNode;154;-1661.261,515.0738;Float;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TextureCoordinatesNode;155;-1661.261,625.0738;Float;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleTimeNode;89;-1588.997,1050.403;Float;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;90;-1563.802,1126.854;Float;False;Property;_Mult1;Mult1;5;0;Create;True;0;0;False;0;2;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TexCoordVertexDataNode;149;-1635.094,845.4035;Float;False;1;3;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TextureCoordinatesNode;156;-1662.261,735.0738;Float;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;91;-1563.766,1196.387;Float;False;Property;_Mult2;Mult2;6;0;Create;True;0;0;False;0;2;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TexturePropertyNode;87;-1652.547,193.8762;Float;True;Property;_Noise;Noise;7;0;Create;True;0;0;False;0;None;None;False;white;Auto;0;1;SAMPLER2D;0
Node;AmplifyShaderEditor.FunctionNode;153;-1221.951,562.841;Float;False;QuickPanBlend;-1;;9;d802c4f2e20221343adb48b4670d5a17;0;10;4;SAMPLER2D;;False;5;FLOAT2;0,0;False;12;FLOAT2;0,0;False;7;FLOAT2;0,0;False;13;FLOAT2;0,0;False;8;FLOAT2;0,0;False;14;FLOAT2;0,0;False;15;FLOAT;0;False;29;FLOAT;0;False;30;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;69;-730.8214,727.9998;Float;True;Property;_Mask;Mask;1;0;Create;True;0;0;False;0;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;71;-341.5346,566.6121;Float;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.VertexColorNode;151;-311.3033,403.9654;Float;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;63;-108.4939,518.0471;Float;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.VertexColorNode;152;-669.0985,-256.2261;Float;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;72;-781.3013,-97.30745;Float;True;Property;_LightMap;LightMap;0;0;Create;True;0;0;False;0;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RegisterLocalVarNode;94;59.14914,508.2671;Float;False;opacity;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;95;-317.2737,33.30848;Float;False;94;0;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;62;-435.4764,-168.9511;Float;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;54;-72.80624,-168.9407;Float;False;True;3;Float;ASEMaterialInspector;0;0;Lambert;Diablo/PS_Smoke;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;0;False;0;Transparent;0.5;True;True;0;False;Transparent;;Transparent;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;-1;False;-1;-1;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;0;0;False;0;0;0;False;-1;-1;0;False;-1;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;154;0;78;0
WireConnection;154;1;150;1
WireConnection;155;0;81;0
WireConnection;155;1;150;2
WireConnection;156;0;84;0
WireConnection;156;1;150;3
WireConnection;153;4;87;0
WireConnection;153;5;154;0
WireConnection;153;12;149;1
WireConnection;153;7;155;0
WireConnection;153;13;149;2
WireConnection;153;8;156;0
WireConnection;153;14;149;3
WireConnection;153;15;89;0
WireConnection;153;29;90;0
WireConnection;153;30;91;0
WireConnection;71;0;153;0
WireConnection;71;1;69;4
WireConnection;63;0;151;4
WireConnection;63;1;71;0
WireConnection;94;0;63;0
WireConnection;62;0;152;0
WireConnection;62;1;72;0
WireConnection;54;0;62;0
WireConnection;54;9;95;0
ASEEND*/
//CHKSM=01E0BAC80DCCB00D9C9631C456DC7B37866036E7