﻿#nullable disable
using Microsoft.Maui.Graphics;
using TCollectionView = Microsoft.Maui.Controls.Handlers.Items.Platform.CollectionView;

namespace Microsoft.Maui.Controls.Handlers.Items
{
	public abstract partial class ItemsViewHandler<TItemsView> : ViewHandler<TItemsView, Platform.CollectionView> where TItemsView : ItemsView
	{
		protected override void ConnectHandler(TCollectionView nativeView)
		{
			base.ConnectHandler(nativeView);
			(nativeView as MauiCollectionView<TItemsView>)?.SetupNewElement(VirtualView);
		}

		protected override void DisconnectHandler(TCollectionView nativeView)
		{
			(nativeView as MauiCollectionView<TItemsView>)?.TearDownOldElement(VirtualView);
			base.DisconnectHandler(nativeView);
		}

		public static void MapItemsSource(ItemsViewHandler<TItemsView> handler, ItemsView itemsView)
		{
			(handler.PlatformView as MauiCollectionView<TItemsView>)?.UpdateItemsSource();
		}

		public static void MapHorizontalScrollBarVisibility(ItemsViewHandler<TItemsView> handler, ItemsView itemsView)
		{
			(handler.PlatformView as MauiCollectionView<TItemsView>)?.UpdateHorizontalScrollBarVisibility();
		}

		public static void MapVerticalScrollBarVisibility(ItemsViewHandler<TItemsView> handler, ItemsView itemsView)
		{
			(handler.PlatformView as MauiCollectionView<TItemsView>)?.UpdateVerticalScrollBarVisibility();
		}

		public static void MapItemTemplate(ItemsViewHandler<TItemsView> handler, ItemsView itemsView)
		{
			(handler.PlatformView as MauiCollectionView<TItemsView>)?.UpdateAdaptor();
		}

		public static void MapEmptyView(ItemsViewHandler<TItemsView> handler, ItemsView itemsView)
		{
			(handler.PlatformView as MauiCollectionView<TItemsView>)?.UpdateAdaptor();
		}

		public static void MapEmptyViewTemplate(ItemsViewHandler<TItemsView> handler, ItemsView itemsView)
		{
			(handler.PlatformView as MauiCollectionView<TItemsView>)?.UpdateAdaptor();
		}

		[MissingMapper]
		public static void MapFlowDirection(ItemsViewHandler<TItemsView> handler, ItemsView itemsView)
		{
		}

		public static void MapIsVisible(ItemsViewHandler<TItemsView> handler, ItemsView itemsView)
		{
			handler.PlatformView.UpdateVisibility(itemsView);
		}

		[MissingMapper]
		public static void MapItemsUpdatingScrollMode(ItemsViewHandler<TItemsView> handler, ItemsView itemsView)
		{
		}
		
		public override void PlatformArrange(Rect rect)
		{
			// PlatformView?.Arrange(rect);
			base.PlatformArrange(rect);
		}
		
#if DEBUG

		public override Size GetDesiredSize(double widthConstraint, double heightConstraint)
		{
			if (PlatformView is not { } nativeView)
				return Size.Zero;

			return nativeView.GetDesiredSize(widthConstraint, heightConstraint);
		}

#endif
	}
}
