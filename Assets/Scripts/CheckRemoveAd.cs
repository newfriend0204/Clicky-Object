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
        Debug.Log("CheckRemoveAd ��ũ��Ʈ �۵� ����");
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
        Debug.Log("Unity IAP �ʱ�ȭ ����: " + error + ", �޽���: " + message);
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args) {
        if (string.Equals(args.purchasedProduct.definition.id, kProductIDRemoveAd, System.StringComparison.Ordinal)) {
            Debug.Log("���� ���� ���Ű� Ȯ�εǾ����ϴ�.");
            gameManager.ad = 1;
        } else {
            Debug.Log("������ ��ǰ�� ó���� �� �����ϴ�: " + args.purchasedProduct.definition.id);
        }
        return PurchaseProcessingResult.Complete;
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason) {
        Debug.LogWarning("���� ����: " + product.definition.id + ", ����: " + failureReason);
    }

    private void CheckPurchase() {
        Product product = m_StoreController.products.WithID(kProductIDRemoveAd);
        if (product != null && product.hasReceipt) {
            Debug.Log("���� ���Ű� �̹� ���ŵǾ����ϴ�.");
            gameManager.ad = 1;
        } else {
            Debug.Log("���� ���Ű� ���ŵ��� �ʾҽ��ϴ�.");
        }
    }
}