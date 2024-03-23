using UnityEngine;
using UnityEngine.Purchasing; // Unity IAP 네임스페이스 추가

public class CheckRemoveAd : MonoBehaviour {
    private static IStoreController m_StoreController; // 인앱 구매를 위한 스토어 컨트롤러 참조

    private string removeAdProductId = "remove_ad"; // 광고 제거 상품의 ID
    private GameManager gameManager;

    void Start() {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        if (m_StoreController == null) // 인앱 구매 시스템이 초기화되지 않았다면
        {
            InitializePurchasing(); // 인앱 구매 시스템 초기화
        }
    }

    void InitializePurchasing() {
        if (IsInitialized()) // 이미 초기화되었는지 확인
        {
            return;
        }

        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        builder.AddProduct(removeAdProductId, ProductType.NonConsumable); // 광고 제거 상품 추가
        //UnityPurchasing.Initialize(this, builder);
    }

    private bool IsInitialized() {
        return m_StoreController != null;
    }

    //public void OnInitialized(IStoreController controller, IExtensionProvider extensions) {
    //    m_StoreController = controller;
    //}

    //public void OnInitializeFailed(InitializationFailureReason error) {
    //    Debug.Log("Unity IAP 초기화 실패: " + error);
    //}

    //public void OnInitializeFailed(InitializationFailureReason error, string message) {
    //    Debug.Log("Unity IAP 초기화 실패: " + error + ", 메시지: " + message);
    //}


    //public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args) {
    //    return PurchaseProcessingResult.Complete;
    //}

    //public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason) {
    //    Debug.Log(string.Format("구매 실패: {0}, 이유: {1}", product.definition.id, failureReason));
    //}

    void CheckPurchase() {
        Product product = m_StoreController.products.WithID(removeAdProductId);

        if (product != null && product.hasReceipt) {
            gameManager.ad = 1;
            Debug.Log("광고 제거 상품 구매 확인됨. 광고를 표시하지 않습니다.");
        } else {
            // 상품을 구매하지 않았다면 여기에 광고를 표시하는 로직을 구현하세요.
            Debug.Log("광고 제거 상품 구매 확인되지 않음. 광고를 표시합니다.");
        }
    }

    void Update() {
        if (IsInitialized()) // Unity IAP가 초기화되었다면
        {
            CheckPurchase(); // 구매 여부 확인
        }
    }
}