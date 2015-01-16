﻿using System;
using System.Linq;
using Henu.Navigation;

namespace HenuDemo {

	/*================================================================================================*/
	public class DemoNavItems {

		public NavItemParent Color { get; private set; }
		public NavItemRadio ColorWhite { get; private set; }
		public NavItemRadio ColorRandom { get; private set; }
		public NavItemRadio ColorCustom { get; private set; }
		public NavItemSlider ColorHue { get; private set; }

		public NavItemParent Motion { get; private set; }
		public NavItemCheckbox MotionOrbit { get; private set; }
		public NavItemCheckbox MotionSpin { get; private set; }
		public NavItemCheckbox MotionBob { get; private set; }
		public NavItemCheckbox MotionGrow { get; private set; }
		public NavItemSlider MotionSpeed { get; private set; }

		public NavItemParent Light { get; private set; }
		public NavItemSlider LightPos { get; private set; }
		public NavItemSlider LightInten { get; private set; }
		public NavItemSticky LightSpot { get; private set; }

		public NavItemParent Camera { get; private set; }
		public NavItemRadio CameraCenter { get; private set; }
		public NavItemRadio CameraBack { get; private set; }
		public NavItemRadio CameraTop { get; private set; }
		public NavItemSelector CameraReorient { get; private set; }

		public NavItem[] TopLevelItems { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DemoNavItems() {
			BuildColors();
			BuildMotions();
			BuildLight();
			BuildCamera();

			TopLevelItems = new[] { Color, Motion, Light, Camera };
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static bool IsItemWithin(NavItem pItem, NavItemParent pParent, NavItem.ItemType pType) {
			VerifyParent(pParent);
			return (pItem.Type == pType && pParent.Children.Contains(pItem));
		}

		/*--------------------------------------------------------------------------------------------*/
		public static NavItemRadio GetChosenRadioItem(NavItemParent pParent) {
			VerifyParent(pParent);

			foreach ( NavItem item in pParent.Children ) {
				NavItemRadio radItem = (item as NavItemRadio);

				if ( radItem != null && radItem.Value ) {
					return radItem;
				}
			}

			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void VerifyParent(NavItemParent pParent) {
			if ( pParent.Children != null && pParent.Children.Length != 0 ) {
				return;
			}

			throw new Exception("Parent item '"+pParent.Label+"' has no children.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void BuildColors() {
			Color = new NavItemParent("Color");
			ColorWhite = new NavItemRadio("White");
			ColorRandom = new NavItemRadio("Random");
			ColorCustom = new NavItemRadio("Custom");
			ColorHue = new NavItemSlider("Hue", 3);
			Color.SetChildren(new NavItem[] { ColorWhite, ColorRandom, ColorCustom, ColorHue });
		}

		/*--------------------------------------------------------------------------------------------*/
		private void BuildMotions() {
			Motion = new NavItemParent("Motion");
			MotionOrbit = new NavItemCheckbox("Orbit");
			MotionSpin = new NavItemCheckbox("Spin");
			MotionBob = new NavItemCheckbox("Bob");
			MotionGrow = new NavItemCheckbox("Grow");
			MotionSpeed = new NavItemSlider("Speed", 4);
			Motion.SetChildren(new NavItem[] { MotionOrbit, MotionSpin, MotionBob, MotionGrow, 
				MotionSpeed });
		}

		/*--------------------------------------------------------------------------------------------*/
		private void BuildLight() {
			Light = new NavItemParent("Lighting");
			LightPos = new NavItemSlider("Position", 2);
			LightInten = new NavItemSlider("Intensity", 2);
			LightSpot = new NavItemSticky("Spotlight");
			Light.SetChildren(new NavItem[] { LightPos, LightInten, LightSpot });
		}

		/*--------------------------------------------------------------------------------------------*/
		private void BuildCamera() {
			Camera = new NavItemParent("Camera");
			CameraCenter = new NavItemRadio("Center");
			CameraBack = new NavItemRadio("Back");
			CameraTop = new NavItemRadio("Top");
			CameraReorient = new NavItemSelector("Re-orient");
			Camera.SetChildren(new NavItem[] { CameraCenter, CameraBack, CameraTop, 
				CameraReorient });
		}

	}

}
