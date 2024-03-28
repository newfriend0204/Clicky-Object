using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class CheckRemoveAd : MonoBehaviour, IStoreListener {
    private static IStoreController m_StoreController;
    private static IExtensionProvider m_StoreExtensionProvider;

    public static string kProductIDRemoveAd = "remove_ad";
    GameManager gameManager;
    void Start() {
        Debug.Log("CheckRemoveAd 스크립트 작동 시작");
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        if (m_StoreController == null) {
            InitializePurchasing();
            CheckPurchase();
        }
    }

    void InitializePurchasing() {
        if (IsInitialized()) {
            return;
        }

        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        builder.AddProduct(kProductIDRemoveAd, ProductType.NonConsumable);
        UnityPurchasing.ClearTransactionLog();
        UnityPurchasing.Initialize(this, builder);
    }

    private bool IsInitialized() {
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions) {
        m_StoreController = controller;
        m_StoreExtensionProvider = extensions;
        CheckPurchase();
    }

    public void OnInitializeFailed(InitializationFailureReason error) {
        Debug.Log("Unity IAP initialization failed: " + error);
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message) {
        Debug.Log("Unity IAP 초기화 실패: " + error + ", 메시지: " + message);
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args) {
        if (string.Equals(args.purchasedProduct.definition.id, kProductIDRemoveAd, System.StringComparison.Ordinal)) {
            Debug.Log("광고 제거 구매가 확인되었습니다.");
            gameManager.ad = 1;
        } else {
            Debug.Log("구매한 상품을 처리할 수 없습니다: " + args.purchasedProduct.definition.id);
        }
        return PurchaseProcessingResult.Complete;
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason) {
        Debug.LogWarning("구매 실패: " + product.definition.id + ", 이유: " + failureReason);
    }

    private void CheckPurchase() {
        Product product = m_StoreController.products.WithID(kProductIDRemoveAd);
        if (product != null && product.hasReceipt) {
            Debug.Log("광고 제거가 이미 구매되었습니다.");
            gameManager.ad = 1;
        } else {
            Debug.Log("광고 제거가 구매되지 않았습니다.");
        }
    }
}