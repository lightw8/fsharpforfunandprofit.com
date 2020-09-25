namespace DiscriminatedUnions
{
    public class Choice<A, B>
    {
        public static implicit operator Choice<A, B>(A value) => new Choice<A, B>(value);
        public static implicit operator Choice<A, B>(B value) => new Choice<A, B>(value);

        public Choice(A item) { Item = item; }
        public Choice(B item) { Item = item; }

        public dynamic Item { get; }
    }

    public class Choice<A, B, C>
    {
        public static implicit operator Choice<A, B, C>(A value) => new Choice<A, B, C>(value);
        public static implicit operator Choice<A, B, C>(B value) => new Choice<A, B, C>(value);
        public static implicit operator Choice<A, B, C>(C value) => new Choice<A, B, C>(value);

        public Choice(A item) { Item = item; }
        public Choice(B item) { Item = item; }
        public Choice(C item) { Item = item; }

        public dynamic Item { get; }
    }

    public class Choice<A, B, C, D>
    {
        public static implicit operator Choice<A, B, C, D>(A value) => new Choice<A, B, C, D>(value);
        public static implicit operator Choice<A, B, C, D>(B value) => new Choice<A, B, C, D>(value);
        public static implicit operator Choice<A, B, C, D>(C value) => new Choice<A, B, C, D>(value);
        public static implicit operator Choice<A, B, C, D>(D value) => new Choice<A, B, C, D>(value);

        public Choice(A item) { Item = item; }
        public Choice(B item) { Item = item; }
        public Choice(C item) { Item = item; }
        public Choice(D item) { Item = item; }

        public dynamic Item { get; }
    }

    public class Choice<A, B, C, D, E>
    {
        public static implicit operator Choice<A, B, C, D, E>(A value) => new Choice<A, B, C, D, E>(value);
        public static implicit operator Choice<A, B, C, D, E>(B value) => new Choice<A, B, C, D, E>(value);
        public static implicit operator Choice<A, B, C, D, E>(C value) => new Choice<A, B, C, D, E>(value);
        public static implicit operator Choice<A, B, C, D, E>(D value) => new Choice<A, B, C, D, E>(value);
        public static implicit operator Choice<A, B, C, D, E>(E value) => new Choice<A, B, C, D, E>(value);

        public Choice(A item) { Item = item; }
        public Choice(B item) { Item = item; }
        public Choice(C item) { Item = item; }
        public Choice(D item) { Item = item; }
        public Choice(E item) { Item = item; }

        public dynamic Item { get; }
    }

    public class Choice<A, B, C, D, E, F>
    {
        public static implicit operator Choice<A, B, C, D, E, F>(A value) => new Choice<A, B, C, D, E, F>(value);
        public static implicit operator Choice<A, B, C, D, E, F>(B value) => new Choice<A, B, C, D, E, F>(value);
        public static implicit operator Choice<A, B, C, D, E, F>(C value) => new Choice<A, B, C, D, E, F>(value);
        public static implicit operator Choice<A, B, C, D, E, F>(D value) => new Choice<A, B, C, D, E, F>(value);
        public static implicit operator Choice<A, B, C, D, E, F>(E value) => new Choice<A, B, C, D, E, F>(value);
        public static implicit operator Choice<A, B, C, D, E, F>(F value) => new Choice<A, B, C, D, E, F>(value);

        public Choice(A item) { Item = item; }
        public Choice(B item) { Item = item; }
        public Choice(C item) { Item = item; }
        public Choice(D item) { Item = item; }
        public Choice(E item) { Item = item; }
        public Choice(F item) { Item = item; }

        public dynamic Item { get; }
    }

    public class Choice<A, B, C, D, E, F, G>
    {
        public static implicit operator Choice<A, B, C, D, E, F, G>(A value) => new Choice<A, B, C, D, E, F, G>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G>(B value) => new Choice<A, B, C, D, E, F, G>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G>(C value) => new Choice<A, B, C, D, E, F, G>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G>(D value) => new Choice<A, B, C, D, E, F, G>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G>(E value) => new Choice<A, B, C, D, E, F, G>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G>(F value) => new Choice<A, B, C, D, E, F, G>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G>(G value) => new Choice<A, B, C, D, E, F, G>(value);

        public Choice(A item) { Item = item; }
        public Choice(B item) { Item = item; }
        public Choice(C item) { Item = item; }
        public Choice(D item) { Item = item; }
        public Choice(E item) { Item = item; }
        public Choice(F item) { Item = item; }
        public Choice(G item) { Item = item; }

        public dynamic Item { get; }
    }

    public class Choice<A, B, C, D, E, F, G, H>
    {
        public static implicit operator Choice<A, B, C, D, E, F, G, H>(A value) => new Choice<A, B, C, D, E, F, G, H>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H>(B value) => new Choice<A, B, C, D, E, F, G, H>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H>(C value) => new Choice<A, B, C, D, E, F, G, H>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H>(D value) => new Choice<A, B, C, D, E, F, G, H>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H>(E value) => new Choice<A, B, C, D, E, F, G, H>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H>(F value) => new Choice<A, B, C, D, E, F, G, H>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H>(G value) => new Choice<A, B, C, D, E, F, G, H>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H>(H value) => new Choice<A, B, C, D, E, F, G, H>(value);

        public Choice(A item) { Item = item; }
        public Choice(B item) { Item = item; }
        public Choice(C item) { Item = item; }
        public Choice(D item) { Item = item; }
        public Choice(E item) { Item = item; }
        public Choice(F item) { Item = item; }
        public Choice(G item) { Item = item; }
        public Choice(H item) { Item = item; }

        public dynamic Item { get; }
    }

    public class Choice<A, B, C, D, E, F, G, H, I>
    {
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I>(A value) => new Choice<A, B, C, D, E, F, G, H, I>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I>(B value) => new Choice<A, B, C, D, E, F, G, H, I>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I>(C value) => new Choice<A, B, C, D, E, F, G, H, I>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I>(D value) => new Choice<A, B, C, D, E, F, G, H, I>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I>(E value) => new Choice<A, B, C, D, E, F, G, H, I>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I>(F value) => new Choice<A, B, C, D, E, F, G, H, I>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I>(G value) => new Choice<A, B, C, D, E, F, G, H, I>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I>(H value) => new Choice<A, B, C, D, E, F, G, H, I>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I>(I value) => new Choice<A, B, C, D, E, F, G, H, I>(value);

        public Choice(A item) { Item = item; }
        public Choice(B item) { Item = item; }
        public Choice(C item) { Item = item; }
        public Choice(D item) { Item = item; }
        public Choice(E item) { Item = item; }
        public Choice(F item) { Item = item; }
        public Choice(G item) { Item = item; }
        public Choice(H item) { Item = item; }
        public Choice(I item) { Item = item; }

        public dynamic Item { get; }
    }

    public class Choice<A, B, C, D, E, F, G, H, I, J>
    {
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J>(A value) => new Choice<A, B, C, D, E, F, G, H, I, J>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J>(B value) => new Choice<A, B, C, D, E, F, G, H, I, J>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J>(C value) => new Choice<A, B, C, D, E, F, G, H, I, J>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J>(D value) => new Choice<A, B, C, D, E, F, G, H, I, J>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J>(E value) => new Choice<A, B, C, D, E, F, G, H, I, J>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J>(F value) => new Choice<A, B, C, D, E, F, G, H, I, J>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J>(G value) => new Choice<A, B, C, D, E, F, G, H, I, J>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J>(H value) => new Choice<A, B, C, D, E, F, G, H, I, J>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J>(I value) => new Choice<A, B, C, D, E, F, G, H, I, J>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J>(J value) => new Choice<A, B, C, D, E, F, G, H, I, J>(value);

        public Choice(A item) { Item = item; }
        public Choice(B item) { Item = item; }
        public Choice(C item) { Item = item; }
        public Choice(D item) { Item = item; }
        public Choice(E item) { Item = item; }
        public Choice(F item) { Item = item; }
        public Choice(G item) { Item = item; }
        public Choice(H item) { Item = item; }
        public Choice(I item) { Item = item; }
        public Choice(J item) { Item = item; }

        public dynamic Item { get; }
    }

    public class Choice<A, B, C, D, E, F, G, H, I, J, K>
    {
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J, K>(A value) => new Choice<A, B, C, D, E, F, G, H, I, J, K>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J, K>(B value) => new Choice<A, B, C, D, E, F, G, H, I, J, K>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J, K>(C value) => new Choice<A, B, C, D, E, F, G, H, I, J, K>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J, K>(D value) => new Choice<A, B, C, D, E, F, G, H, I, J, K>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J, K>(E value) => new Choice<A, B, C, D, E, F, G, H, I, J, K>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J, K>(F value) => new Choice<A, B, C, D, E, F, G, H, I, J, K>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J, K>(G value) => new Choice<A, B, C, D, E, F, G, H, I, J, K>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J, K>(H value) => new Choice<A, B, C, D, E, F, G, H, I, J, K>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J, K>(I value) => new Choice<A, B, C, D, E, F, G, H, I, J, K>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J, K>(J value) => new Choice<A, B, C, D, E, F, G, H, I, J, K>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J, K>(K value) => new Choice<A, B, C, D, E, F, G, H, I, J, K>(value);

        public Choice(A item) { Item = item; }
        public Choice(B item) { Item = item; }
        public Choice(C item) { Item = item; }
        public Choice(D item) { Item = item; }
        public Choice(E item) { Item = item; }
        public Choice(F item) { Item = item; }
        public Choice(G item) { Item = item; }
        public Choice(H item) { Item = item; }
        public Choice(I item) { Item = item; }
        public Choice(J item) { Item = item; }
        public Choice(K item) { Item = item; }

        public dynamic Item { get; }
    }

    public class Choice<A, B, C, D, E, F, G, H, I, J, K, L>
    {
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J, K, L>(A value) => new Choice<A, B, C, D, E, F, G, H, I, J, K, L>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J, K, L>(B value) => new Choice<A, B, C, D, E, F, G, H, I, J, K, L>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J, K, L>(C value) => new Choice<A, B, C, D, E, F, G, H, I, J, K, L>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J, K, L>(D value) => new Choice<A, B, C, D, E, F, G, H, I, J, K, L>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J, K, L>(E value) => new Choice<A, B, C, D, E, F, G, H, I, J, K, L>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J, K, L>(F value) => new Choice<A, B, C, D, E, F, G, H, I, J, K, L>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J, K, L>(G value) => new Choice<A, B, C, D, E, F, G, H, I, J, K, L>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J, K, L>(H value) => new Choice<A, B, C, D, E, F, G, H, I, J, K, L>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J, K, L>(I value) => new Choice<A, B, C, D, E, F, G, H, I, J, K, L>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J, K, L>(J value) => new Choice<A, B, C, D, E, F, G, H, I, J, K, L>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J, K, L>(K value) => new Choice<A, B, C, D, E, F, G, H, I, J, K, L>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J, K, L>(L value) => new Choice<A, B, C, D, E, F, G, H, I, J, K, L>(value);

        public Choice(A item) { Item = item; }
        public Choice(B item) { Item = item; }
        public Choice(C item) { Item = item; }
        public Choice(D item) { Item = item; }
        public Choice(E item) { Item = item; }
        public Choice(F item) { Item = item; }
        public Choice(G item) { Item = item; }
        public Choice(H item) { Item = item; }
        public Choice(I item) { Item = item; }
        public Choice(J item) { Item = item; }
        public Choice(K item) { Item = item; }
        public Choice(L item) { Item = item; }

        public dynamic Item { get; }
    }

    public class Choice<A, B, C, D, E, F, G, H, I, J, K, L, M>
    {
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J, K, L, M>(A value) => new Choice<A, B, C, D, E, F, G, H, I, J, K, L, M>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J, K, L, M>(B value) => new Choice<A, B, C, D, E, F, G, H, I, J, K, L, M>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J, K, L, M>(C value) => new Choice<A, B, C, D, E, F, G, H, I, J, K, L, M>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J, K, L, M>(D value) => new Choice<A, B, C, D, E, F, G, H, I, J, K, L, M>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J, K, L, M>(E value) => new Choice<A, B, C, D, E, F, G, H, I, J, K, L, M>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J, K, L, M>(F value) => new Choice<A, B, C, D, E, F, G, H, I, J, K, L, M>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J, K, L, M>(G value) => new Choice<A, B, C, D, E, F, G, H, I, J, K, L, M>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J, K, L, M>(H value) => new Choice<A, B, C, D, E, F, G, H, I, J, K, L, M>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J, K, L, M>(I value) => new Choice<A, B, C, D, E, F, G, H, I, J, K, L, M>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J, K, L, M>(J value) => new Choice<A, B, C, D, E, F, G, H, I, J, K, L, M>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J, K, L, M>(K value) => new Choice<A, B, C, D, E, F, G, H, I, J, K, L, M>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J, K, L, M>(L value) => new Choice<A, B, C, D, E, F, G, H, I, J, K, L, M>(value);
        public static implicit operator Choice<A, B, C, D, E, F, G, H, I, J, K, L, M>(M value) => new Choice<A, B, C, D, E, F, G, H, I, J, K, L, M>(value);

        public Choice(A item) { Item = item; }
        public Choice(B item) { Item = item; }
        public Choice(C item) { Item = item; }
        public Choice(D item) { Item = item; }
        public Choice(E item) { Item = item; }
        public Choice(F item) { Item = item; }
        public Choice(G item) { Item = item; }
        public Choice(H item) { Item = item; }
        public Choice(I item) { Item = item; }
        public Choice(J item) { Item = item; }
        public Choice(K item) { Item = item; }
        public Choice(L item) { Item = item; }
        public Choice(M item) { Item = item; }

        public dynamic Item { get; }
    }
}
